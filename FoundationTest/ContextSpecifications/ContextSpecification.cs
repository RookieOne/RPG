using NUnit.Framework;
using Rhino.Mocks;

namespace FoundationTest.ContextSpecifications
{
    /// <summary>
    /// Base context specification
    /// </summary>
    public class ContextSpecification
    {
        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {                   
            _mock = new MockRepository();
            Given();        
        }

        protected MockRepository _mock;

        /// <summary>
        /// Given
        /// </summary>
        public virtual void Given()
        {
        }

        /// <summary>
        /// When
        /// </summary>
        protected void When()
        {
            _mock.ReplayAll();
            OnWhen();
            _mock.VerifyAll();
        }

        /// <summary>
        /// When
        /// </summary>
        public virtual void OnWhen()
        {
        }
    }
}