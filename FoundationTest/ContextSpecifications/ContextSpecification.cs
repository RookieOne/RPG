namespace FoundationTest.ContextSpecifications
{
    /// <summary>
    /// Base context specification
    /// </summary>
    public class ContextSpecification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextSpecification"/> class.
        /// </summary>
        public ContextSpecification()
        {
            Given();
            When();
        }

        /// <summary>
        /// Given
        /// </summary>
        public virtual void Given()
        {
        }

        /// <summary>
        /// When
        /// </summary>
        public virtual void When()
        {
        }
    }
}