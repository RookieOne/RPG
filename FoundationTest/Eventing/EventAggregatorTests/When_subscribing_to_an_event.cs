using System;
using Foundation.Eventing;
using FoundationTest.ContextSpecifications;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.EventAggregatorTests
{
    [TestFixture]
    public class When_subscribing_to_an_event : WithEventing
    {
        private Action<MockEvent> _action;

        public override void When()
        {
            base.When();

            _action = (m) => { };

            EventAggregator.Subscribe(_action);
        }

        [Test]
        public void should_have_only_one_subscription()
        {
            Assert.AreEqual(1, _eventAggregator.SubscriptionCount[typeof (MockEvent).Name]);
        }
    }
}