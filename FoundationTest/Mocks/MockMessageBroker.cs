using System;
using System.Collections.Generic;
using Foundation.Messaging;

namespace FoundationTest.Mocks
{
    public class MockMessageBroker : IMessageBroker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockEventAggregator"/> class.
        /// </summary>
        public MockMessageBroker()
        {
            SentCount = new Dictionary<string, int>();
            RegistrationCount = new Dictionary<string, int>();
            _messageBroker = new DefaultMessageBroker();
        }

        private readonly DefaultMessageBroker _messageBroker;

        /// <summary>
        /// Gets or sets the registration count.
        /// </summary>
        /// <value>The registration count.</value>
        public Dictionary<string, int> RegistrationCount { get; private set; }

        /// <summary>
        /// Gets or sets the message sent count.
        /// </summary>
        /// <value>The message sent count.</value>
        public Dictionary<string, int> SentCount { get; private set; }

        /// <summary>
        /// Records publication.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        private void RecordMessageSent(string eventName)
        {
            if (!SentCount.ContainsKey(eventName))
                SentCount.Add(eventName, 0);

            SentCount[eventName]++;
        }

        /// <summary>
        /// Records the subscription.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        private void RecordRegistration(string eventName)
        {
            if (!RegistrationCount.ContainsKey(eventName))
                RegistrationCount.Add(eventName, 0);

            RegistrationCount[eventName]++;
        }

        /// <summary>
        /// Registers action for the specified message by name.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        /// <param name="consumptionAction">The consumption action.</param>
        public void Register(string messageName, Action consumptionAction)
        {
            RecordRegistration(messageName);
            _messageBroker.Register(messageName, consumptionAction);
        }

        /// <summary>
        /// Registers the specified consumption action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="consumptionAction">The consumption action.</param>
        public void Register<T>(Action<T> consumptionAction)
        {
            RecordRegistration(typeof (T).Name);
            _messageBroker.Register(consumptionAction);
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        public void Send<T>(T message)
        {
            RecordMessageSent(typeof (T).Name);
            _messageBroker.Send(message);
        }

        /// <summary>
        /// Sends the specified message with given name.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        public void Send(string messageName)
        {
            RecordMessageSent(messageName);
            _messageBroker.Send(messageName);
        }
    }
}