using Foundation.Eventing;
using FoundationTest.ContextSpecifications;

namespace FoundationTest.Eventing.Contexts
{
    /// <summary>
    /// Has a new default event aggregator
    /// </summary>
    public class NewDefaultEventAggregator : ContextSpecification
    {
        protected DefaultEventAggregator _eventAggregator;

        /// <summary>
        /// Given
        /// </summary>
        public override void Given()
        {
            base.Given();

            _eventAggregator = new DefaultEventAggregator();
        }
    }
}