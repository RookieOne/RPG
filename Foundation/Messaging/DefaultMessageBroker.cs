using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Extensions;

namespace Foundation.Messaging
{
    /// <summary>
    /// Default implementation of IMessageBroker
    /// </summary>
    public class DefaultMessageBroker : IMessageBroker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMessageBroker"/> class.
        /// </summary>
        public DefaultMessageBroker()
        {
            _registrations = new Dictionary<Type, List<object>>();
            _registrationsByName = new Dictionary<string, List<object>>();
        }

        public Dictionary<Type, List<object>> _registrations;
        public Dictionary<string, List<object>> _registrationsByName;

        /// <summary>
        /// Registers action for the specified message by name.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        /// <param name="consumptionAction">The consumption action.</param>
        public void Register(string messageName, Action consumptionAction)
        {
            if (!_registrationsByName.ContainsKey(messageName))
                _registrationsByName.Add(messageName, new List<object>());

            _registrationsByName[messageName].Add(consumptionAction);
        }

        /// <summary>
        /// Registers action for the specified message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="consumptionAction">The consumption action.</param>
        public void Register<T>(Action<T> consumptionAction)
        {
            Type eventType = typeof (T);

            if (!_registrations.ContainsKey(eventType))
                _registrations.Add(eventType, new List<object>());

            _registrations[eventType].Add(consumptionAction);
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        public void Send<T>(T message)
        {
            Type messageType = typeof (T);

            if (!_registrations.ContainsKey(messageType))
                return;

            _registrations[messageType]
                .Cast<Action<T>>()
                .ForEach(a => a.Invoke(message));
        }

        /// <summary>
        /// Sends the specified message with given name.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        public void Send(string messageName)
        {
            if (!_registrationsByName.ContainsKey(messageName))
                return;

            _registrationsByName[messageName]
                .Cast<Action>()
                .ForEach(a => a.Invoke());
        }
    }
}