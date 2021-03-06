﻿using System;
using FoundationTest.Messaging.Contexts;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Messaging.DefaultMessageBrokerTests
{
    [TestFixture]
    public class When_sending_a_message_with_a_single_registration : NewDefaultMessageBroker
    {
        private Action<MockMessage> _action;
        private bool _actionExecuted;

        public override void Given()
        {
            base.Given();

            _actionExecuted = false;
            _action = (m) => { _actionExecuted = true; };

            _messageBroker.Register(_action);
        }

        public override void OnWhen()
        {
            base.OnWhen();

            _messageBroker.Send(new MockMessage());
        }

        [Test]
        public void should_execute_action()
        {
            When();
            Assert.IsTrue(_actionExecuted);
        }
    }
}