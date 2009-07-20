using System;
using FoundationTest.Eventing.Contexts;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.DefaultEventAggregatorTests
{
    /// <summary>
    /// When subscribing to an event
    /// </summary>
    [TestFixture]
    public class When_subscribing_to_an_event : NewDefaultEventAggregator
    {
        private Action<MockEvent> _action;

        public override void OnWhen()
        {
            base.OnWhen();

            _action = (m) => { };

            _eventAggregator.Subscribe(_action);
        }

        [Test]
        public void should_add_action_to_subscription_list()
        {
            When();
            Assert.IsTrue(_eventAggregator._subscriptions[typeof (MockEvent)].Contains(_action));
        }

        [Test]
        public void should_have_only_one_subscription()
        {
            When();
            Assert.AreEqual(1, _eventAggregator._subscriptions[typeof (MockEvent)].Count);
        }
    }
}