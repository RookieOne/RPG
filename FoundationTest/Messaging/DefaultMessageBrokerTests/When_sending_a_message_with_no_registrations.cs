﻿using FoundationTest.Messaging.Contexts;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Messaging.DefaultMessageBrokerTests
{
    [TestFixture]
    public class When_sending_a_message_with_no_registrations : NewDefaultMessageBroker
    {
        public override void OnWhen()
        {
            base.OnWhen();

            _messageBroker.Send(new MockMessage());
        }

        [Test]
        public void should_not_throw_an_exception()
        {
            When();
            Assert.IsTrue(true);
        }
    }
}