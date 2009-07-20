using Foundation.Messaging;
using FoundationTest.ContextSpecifications;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Messaging.MessageBrokerTests
{
    [TestFixture]
    public class When_sending_a_message_by_name : WithMessaging
    {
        public override void OnWhen()
        {
            base.OnWhen();

            MessageBroker.Send(MockMessage.Name);
        }

        [Test]
        public void should_send_message()
        {
            When();
            Assert.AreEqual(1, _messageBroker.SentCount[MockMessage.Name]);
        }
    }
}