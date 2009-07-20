using FoundationTest.Eventing.Contexts;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.DefaultEventAggregatorTests
{
    [TestFixture]
    public class When_publishing_an_event_by_name_with_no_subscriptions : NewDefaultEventAggregator
    {
        public override void OnWhen()
        {
            base.OnWhen();

            _eventAggregator.Publish(MockEvent.Name);
        }

        [Test]
        public void should_not_throw_an_exception()
        {
            When();
            Assert.IsTrue(true);
        }
    }
}