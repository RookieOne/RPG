using System;

namespace Foundation.Eventing
{
    /// <summary>
    /// Event Aggregator is a facade to access the event aggregator for the system
    /// </summary>
    public class EventAggregator
    {
        /// <summary>
        /// Initializes the <see cref="EventAggregator"/> class.
        /// </summary>
        static EventAggregator()
        {
            _eventAggregator = new DefaultEventAggregator();
        }

        private static IEventAggregator _eventAggregator;

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventToPublish">The event to publish.</param>
        public static void Publish<T>(T eventToPublish)
        {
            _eventAggregator.Publish(eventToPublish);
        }

        /// <summary>
        /// Publishes the specified event name.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        public static void Publish(string eventName)
        {
            _eventAggregator.Publish(eventName);
        }

        /// <summary>
        /// Sets the aggregator.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public static void SetAggregator(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        /// <summary>
        /// Subscribes to the specified event with the given action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subscriptionAction">The subscription action.</param>
        public static IEventAggregator Subscribe<T>(Action<T> subscriptionAction)
        {
            _eventAggregator.Subscribe(subscriptionAction);
            return _eventAggregator;
        }

        /// <summary>
        /// Subscribes the specified event by name with the given action.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="subscriptionAction">The subscription action.</param>
        public static void Subscribe(string eventName, Action subscriptionAction)
        {
            _eventAggregator.Subscribe(eventName, subscriptionAction);
        }
    }
}