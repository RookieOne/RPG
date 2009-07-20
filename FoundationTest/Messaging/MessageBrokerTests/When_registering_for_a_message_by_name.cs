using System;
using Foundation.Messaging;
using FoundationTest.ContextSpecifications;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Messaging.MessageBrokerTests
{
    [TestFixture]
    public class When_registering_for_a_message_by_name : WithMessaging
    {
        private Action _action;

        public override void OnWhen()
        {
            base.OnWhen();

            _action = () => { };

            MessageBroker.Register(MockMessage.Name, _action);
        }

        [Test]
        public void should_have_only_one_registration()
        {
            When();
            Assert.AreEqual(1, _messageBroker.RegistrationCount[MockMessage.Name]);
        }
    }
}