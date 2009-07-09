using System;
using Foundation.Eventing;
using FoundationTest.ContextSpecifications;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.EventAggregatorTests
{
    [TestFixture]
    public class When_subscribing_to_an_event_by_name : WithEventing
    {
        private Action _action;

        public override void When()
        {
            base.When();

            _action = () => { };

            EventAggregator.Subscribe(MockEvent.Name, _action);
        }

        [Test]
        public void should_have_only_one_subscription()
        {
            Assert.AreEqual(1, _eventAggregator.SubscriptionCount[MockEvent.Name]);
        }
    }
}