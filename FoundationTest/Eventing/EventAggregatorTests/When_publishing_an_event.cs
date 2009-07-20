using Foundation.Eventing;
using FoundationTest.ContextSpecifications;
using FoundationTest.Mocks;
using NUnit.Framework;

namespace FoundationTest.Eventing.EventAggregatorTests
{
    [TestFixture]
    public class When_publishing_an_event : WithEventing
    {
        public override void OnWhen()
        {
            base.OnWhen();

            EventAggregator.Publish(new MockEvent());
        }

        [Test]
        public void should_publish_event()
        {
            When();
            Assert.AreEqual(1, _eventAggregator.PublicationCount[typeof (MockEvent).Name]);
        }
    }
}