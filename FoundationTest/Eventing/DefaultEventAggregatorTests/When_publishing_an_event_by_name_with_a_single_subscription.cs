using System;
using FoundationTest.Eventing.Contexts;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.DefaultEventAggregatorTests
{
    [TestFixture]
    public class When_publishing_an_event_by_name_with_a_single_subscription : NewDefaultEventAggregator
    {
        private Action _action;
        private bool _actionExecuted;

        public override void Given()
        {
            base.Given();

            _actionExecuted = false;
            _action = () => { _actionExecuted = true; };

            _eventAggregator.Subscribe(MockEvent.Name, _action);
        }

        public override void OnWhen()
        {
            base.OnWhen();

            _eventAggregator.Publish(MockEvent.Name);
        }

        [Test]
        public void should_execute_subscription_action()
        {
            When();
            Assert.IsTrue(_actionExecuted);
        }
    }
}