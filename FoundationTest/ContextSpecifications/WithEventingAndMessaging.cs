using Foundation.Eventing;
using Foundation.Messaging;
using FoundationTest.Mocks;

namespace FoundationTest.ContextSpecifications
{
    /// <summary>
    /// With Eventing and Messaging
    /// </summary>
    public class WithEventingAndMessaging : ContextSpecification
    {
        protected MockEventAggregator _eventAggregator;
        protected MockMessageBroker _messageBroker;

        /// <summary>
        /// Given
        /// </summary>
        public override void Given()
        {
            base.Given();

            _eventAggregator = new MockEventAggregator();
            EventAggregator.SetAggregator(_eventAggregator);


            _messageBroker = new MockMessageBroker();
            MessageBroker.SetMessageBroker(_messageBroker);
        }
    }
}