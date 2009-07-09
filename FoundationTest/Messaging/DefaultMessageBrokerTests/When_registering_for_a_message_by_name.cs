using System;
using FoundationTest.Messaging.Contexts;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Messaging.DefaultMessageBrokerTests
{
    [TestFixture]
    public class When_registering_for_a_message_by_name : NewDefaultMessageBroker
    {
        private Action _action;

        public override void When()
        {
            base.When();

            _action = () => { };

            _messageBroker.Register(MockMessage.Name, _action);
        }

        [Test]
        public void should_have_only_one_registration()
        {
            Assert.AreEqual(1, _messageBroker._registrationsByName[MockMessage.Name].Count);
        }

        [Test]
        public void should_register_action_for_message()
        {
            Assert.IsTrue(_messageBroker._registrationsByName[MockMessage.Name].Contains(_action));
        }
    }
}