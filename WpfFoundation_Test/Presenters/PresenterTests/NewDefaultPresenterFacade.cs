using FoundationTest.ContextSpecifications;
using WpfFoundation.Presenters;

namespace WpfFoundation_Test.Presenters.PresenterTests
{
    public class NewDefaultPresenterFacade : ContextSpecification
    {
        protected DefaultPresenterFacade _facade;

        public override void Given()
        {
            base.Given();

            _facade = new DefaultPresenterFacade();
        }
    }
}