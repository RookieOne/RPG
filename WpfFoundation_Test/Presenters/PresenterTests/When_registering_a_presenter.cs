using FoundationTest.ContextSpecifications;
using NUnit.Framework;
using WpfFoundation.Presenters;

namespace WpfFoundation_Test.Presenters.PresenterTests
{
    [TestFixture]
    public class When_registering_a_presenter : NewDefaultPresenterFacade
    {
        private IPresenter _presenter;
        private string _key;
        
        public override void Given()
        {
            base.Given();
            
            _key = "Test";
            _presenter = _mock.DynamicMock<IPresenter>();
        }

        public override void OnWhen()
        {
            base.OnWhen();

            _facade.Register(_key, _presenter);
        }

        [Test]
        public void should_have_presenter_in_collection_under_key()
        {
            When();
            Assert.AreEqual(_presenter, _facade._presenters[_key]);
        }
    }
}