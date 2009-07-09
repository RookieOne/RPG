using Foundation.Messaging;
using FoundationTest.ContextSpecifications;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Messaging.MessageBrokerTests
{
    [TestFixture]
    public class When_sending_a_message : WithMessaging
    {
        public override void When()
        {
            base.When();

            MessageBroker.Send(new MockMessage());
        }

        [Test]
        public void should_send_message()
        {
            Assert.AreEqual(1, _messageBroker.SentCount[typeof (MockMessage).Name]);
        }
    }
}