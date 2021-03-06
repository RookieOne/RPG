﻿using System;
using FoundationTest.Messaging.Contexts;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Messaging.DefaultMessageBrokerTests
{
    [TestFixture]
    public class When_registering_for_a_message : NewDefaultMessageBroker
    {
        private Action<MockMessage> _action;

        public override void OnWhen()
        {
            base.OnWhen();

            _action = (m) => { };

            _messageBroker.Register(_action);
        }

        [Test]
        public void should_have_only_one_registration()
        {
            When();
            Assert.AreEqual(1, _messageBroker._registrations[typeof (MockMessage)].Count);
        }

        [Test]
        public void should_register_action_for_message()
        {
            When();
            Assert.IsTrue(_messageBroker._registrations[typeof (MockMessage)].Contains(_action));
        }
    }
}