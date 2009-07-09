using System;

namespace Foundation.Eventing
{
    /// <summary>
    /// Interface for Event Aggregator
    /// </summary>
    public interface IEventAggregator
    {
        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventToPublish">The event to publish.</param>
        void Publish<T>(T eventToPublish);

        /// <summary>
        /// Publishes the specified event name.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        void Publish(string eventName);

        /// <summary>
        /// Subscribes to the specified event with the given action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subscriptionAction">The subscription action.</param>
        void Subscribe<T>(Action<T> subscriptionAction);

        /// <summary>
        /// Subscribes the specified event by name with the given action.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="subscriptionAction">The subscription action.</param>
        void Subscribe(string eventName, Action subscriptionAction);
    }
}