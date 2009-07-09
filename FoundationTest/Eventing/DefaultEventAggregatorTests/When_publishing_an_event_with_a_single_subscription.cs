using System;
using FoundationTest.Eventing.Contexts;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.DefaultEventAggregatorTests
{
    [TestFixture]
    public class When_publishing_an_event_with_a_single_subscription : NewDefaultEventAggregator
    {
        private Action<MockEvent> _action;
        private bool _actionExecuted;

        public override void Given()
        {
            base.Given();

            _actionExecuted = false;
            _action = (m) => { _actionExecuted = true; };

            _eventAggregator.Subscribe(_action);
        }

        public override void When()
        {
            base.When();

            _eventAggregator.Publish(new MockEvent());
        }

        [Test]
        public void should_execute_subscription_action()
        {
            Assert.IsTrue(_actionExecuted);
        }
    }
}