using Foundation.Messaging;
using FoundationTest.ContextSpecifications;

namespace FoundationTest.Messaging.Contexts
{
    public class NewDefaultMessageBroker : ContextSpecification
    {
        protected DefaultMessageBroker _messageBroker;

        public override void Given()
        {
            base.Given();

            _messageBroker = new DefaultMessageBroker();
        }
    }
}