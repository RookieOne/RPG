using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Extensions;

namespace Foundation.Eventing
{
    /// <summary>
    /// Default implementation of IEventAggregator
    /// </summary>
    public class DefaultEventAggregator : IEventAggregator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultEventAggregator"/> class.
        /// </summary>
        public DefaultEventAggregator()
        {
            _subscriptions = new Dictionary<Type, List<object>>();
            _subscriptionsByName = new Dictionary<string, List<object>>();
        }

        public readonly Dictionary<Type, List<object>> _subscriptions;
        public readonly Dictionary<string, List<object>> _subscriptionsByName;

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventToPublish">The event to publish.</param>
        public void Publish<T>(T eventToPublish)
        {
            Type eventType = typeof (T);

            if (!_subscriptions.ContainsKey(eventType))
                return;

            _subscriptions[eventType]
                .Cast<Action<T>>()
                .ForEach(a => a.Invoke(eventToPublish));
        }

        /// <summary>
        /// Publishes the specified event name.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        public void Publish(string eventName)
        {
            if (!_subscriptionsByName.ContainsKey(eventName))
                return;

            _subscriptionsByName[eventName]
                .Cast<Action>()
                .ForEach(a => a.Invoke());
        }

        /// <summary>
        /// Subscribes to the specified event with the given action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subscriptionAction">The subscription action.</param>
        public void Subscribe<T>(Action<T> subscriptionAction)
        {
            Type eventType = typeof (T);

            if (!_subscriptions.ContainsKey(eventType))
                _subscriptions.Add(eventType, new List<object>());

            _subscriptions[eventType].Add(subscriptionAction);
        }

        /// <summary>
        /// Subscribes the specified event by name with the given action.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="subscriptionAction">The subscription action.</param>
        public void Subscribe(string eventName, Action subscriptionAction)
        {
            if (!_subscriptionsByName.ContainsKey(eventName))
                _subscriptionsByName.Add(eventName, new List<object>());

            _subscriptionsByName[eventName].Add(subscriptionAction);
        }
    }
}