using Foundation.Eventing;
using FoundationTest.ContextSpecifications;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.EventAggregatorTests
{
    [TestFixture]
    public class When_publishing_an_event : WithEventing
    {
        public override void When()
        {
            base.When();

            EventAggregator.Publish(new MockEvent());
        }

        [Test]
        public void should_publish_event()
        {
            Assert.AreEqual(1, _eventAggregator.PublicationCount[typeof (MockEvent).Name]);
        }
    }
}