using System;
using FoundationTest.Eventing.Contexts;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.DefaultEventAggregatorTests
{
    [TestFixture]
    public class When_subscribing_to_an_event_by_name : NewDefaultEventAggregator
    {        
        private Action _action;

        public override void OnWhen()
        {
            base.OnWhen();

            _action = () => { };

            _eventAggregator.Subscribe(MockEvent.Name, _action);
        }

        [Test]
        public void should_add_action_to_subscription_list()
        {
            When();
            Assert.IsTrue(_eventAggregator._subscriptionsByName[MockEvent.Name].Contains(_action));
        }

        [Test]
        public void should_have_only_one_subscription()
        {
            When();
            Assert.AreEqual(1, _eventAggregator._subscriptionsByName[MockEvent.Name].Count);
        }
    }
}