using System;

namespace Foundation.Messaging
{
    /// <summary>
    /// Interface for a Message Broker
    /// </summary>
    public interface IMessageBroker
    {
        /// <summary>
        /// Registers action for the specified message by name.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        /// <param name="consumptionAction">The consumption action.</param>
        void Register(string messageName, Action consumptionAction);

        /// <summary>
        /// Registers action for the specified message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="consumptionAction">The consumption action.</param>
        void Register<T>(Action<T> consumptionAction);

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        void Send<T>(T message);

        /// <summary>
        /// Sends the specified message with given name.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        void Send(string messageName);
    }
}