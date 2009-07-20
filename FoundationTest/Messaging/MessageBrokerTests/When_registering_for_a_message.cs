using System;
using Foundation.Messaging;
using FoundationTest.ContextSpecifications;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Messaging.MessageBrokerTests
{
    [TestFixture]
    public class When_registering_for_a_message : WithMessaging
    {
        private Action<MockMessage> _action;

        public override void OnWhen()
        {
            base.OnWhen();

            _action = (m) => { };

            MessageBroker.Register(_action);
        }

        [Test]
        public void should_have_only_one_registration()
        {
            When();
            Assert.AreEqual(1, _messageBroker.RegistrationCount[typeof (MockMessage).Name]);
        }
    }
}