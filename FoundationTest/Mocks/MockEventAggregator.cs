using System;
using System.Collections.Generic;
using Foundation.Eventing;

namespace FoundationTest.Mocks
{
    /// <summary>
    /// Mock Event Aggregator records published events
    /// </summary>
    public class MockEventAggregator : IEventAggregator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockEventAggregator"/> class.
        /// </summary>
        public MockEventAggregator()
        {
            PublicationCount = new Dictionary<string, int>();
            SubscriptionCount = new Dictionary<string, int>();
            _eventAggregator = new DefaultEventAggregator();
        }

        private readonly DefaultEventAggregator _eventAggregator;

        /// <summary>
        /// Gets or sets the publication count.
        /// </summary>
        /// <value>The publication count.</value>
        public Dictionary<string, int> PublicationCount { get; private set; }

        /// <summary>
        /// Gets or sets the subscription count.
        /// </summary>
        /// <value>The subscription count.</value>
        public Dictionary<string, int> SubscriptionCount { get; private set; }

        /// <summary>
        /// Gets the publication count.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int GetPublicationCount<T>()
        {
            int count;
            return PublicationCount.TryGetValue(typeof (T).Name, out count)
                       ? count
                       : 0;
        }

        /// <summary>
        /// Publishes the specified event to publish.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventToPublish">The event to publish.</param>
        public IEventAggregator Publish<T>(T eventToPublish)
        {
            RecordPublication(typeof (T).Name);
            _eventAggregator.Publish(eventToPublish);
            return this;
        }

        /// <summary>
        /// Publishes the specified event name.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        public IEventAggregator Publish(string eventName)
        {
            RecordPublication(eventName);
            _eventAggregator.Publish(eventName);
            return this;
        }

        /// <summary>
        /// Records publication.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        private void RecordPublication(string eventName)
        {
            if (!PublicationCount.ContainsKey(eventName))
                PublicationCount.Add(eventName, 0);

            PublicationCount[eventName]++;
        }

        /// <summary>
        /// Records the subscription.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        private void RecordSubscription(string eventName)
        {
            if (!SubscriptionCount.ContainsKey(eventName))
                SubscriptionCount.Add(eventName, 0);

            SubscriptionCount[eventName]++;
        }

        /// <summary>
        /// Subscribes the specified subscription action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subscriptionAction">The subscription action.</param>
        public IEventAggregator Subscribe<T>(Action<T> subscriptionAction)
        {
            RecordSubscription(typeof (T).Name);
            _eventAggregator.Subscribe(subscriptionAction);
            return this;
        }

        /// <summary>
        /// Subscribes the specified event by name with the given action.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="subscriptionAction">The subscription action.</param>
        public IEventAggregator Subscribe(string eventName, Action subscriptionAction)
        {
            RecordSubscription(eventName);
            _eventAggregator.Subscribe(eventName, subscriptionAction);
            return this;
        }
    }
}