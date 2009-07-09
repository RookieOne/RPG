using Foundation.Eventing;
using FoundationTest.ContextSpecifications;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.EventAggregatorTests
{
    [TestFixture]
    public class When_publishing_an_event_by_name : WithEventing
    {
        public override void When()
        {
            base.When();

            EventAggregator.Publish(MockEvent.Name);
        }

        [Test]
        public void should_publish_event()
        {
            Assert.AreEqual(1, _eventAggregator.PublicationCount[MockEvent.Name]);
        }
    }
}