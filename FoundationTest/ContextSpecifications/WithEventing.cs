using Foundation.Eventing;
using FoundationTest.Mocks;

namespace FoundationTest.ContextSpecifications
{
    /// <summary>
    /// Basic Context with Eventing
    /// </summary>
    public class WithEventing : ContextSpecification
    {
        protected MockEventAggregator _eventAggregator;

        /// <summary>
        /// Given
        /// </summary>
        public override void Given()
        {
            base.Given();

            _eventAggregator = new MockEventAggregator();
            EventAggregator.SetAggregator(_eventAggregator);
        }
    }
}