using Foundation.Messaging;
using FoundationTest.Mocks;

namespace FoundationTest.ContextSpecifications
{
    public class WithMessaging : ContextSpecification
    {
        protected MockMessageBroker _messageBroker;

        /// <summary>
        /// Given
        /// </summary>
        public override void Given()
        {
            base.Given();

            _messageBroker = new MockMessageBroker();
            MessageBroker.SetMessageBroker(_messageBroker);
        }
    }
}