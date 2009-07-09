using System;

namespace Foundation.Messaging
{
    /// <summary>
    /// Facade helper for Message Broker
    /// </summary>
    public static class MessageBroker
    {
        private static IMessageBroker _messageBroker;

        /// <summary>
        /// Registers action for the specified message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="consumptionAction">The consumption action.</param>
        public static void Register<T>(Action<T> consumptionAction)
        {
            _messageBroker.Register(consumptionAction);
        }

        /// <summary>
        /// Registers action for the specified message by name.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        /// <param name="consumptionAction">The consumption action.</param>
        public static void Register(string messageName, Action consumptionAction)
        {
            _messageBroker.Register(messageName, consumptionAction);
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        public static void Send<T>(T message)
        {
            _messageBroker.Send(message);
        }

        /// <summary>
        /// Sends the specified message name.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        public static void Send(string messageName)
        {
            _messageBroker.Send(messageName);
        }

        /// <summary>
        /// Sets the message broker.
        /// </summary>
        /// <param name="messageBroker">The message broker.</param>
        public static void SetMessageBroker(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }
    }
}