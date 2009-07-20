using FoundationTest.ContextSpecifications;
using NUnit.Framework;
using Rhino.Mocks;
using WpfFoundation.Presenters;
using WpfFoundation.ViewModels;

namespace WpfFoundation_Test.Presenters.PresenterTests
{
    [TestFixture]
    public class When_showing_with_a_registered_presenter : NewDefaultPresenterFacade
    {
        private string _key;
        private IPresenter _presenter;
        private IViewModel _viewModel;

        public override void Given()
        {
            base.Given();

            _key = "Test";
            _presenter = _mock.DynamicMock<IPresenter>();
            _viewModel = _mock.DynamicMock<IViewModel>();

            _facade.Register(_key, _presenter);
        }

        public override void OnWhen()
        {
            base.OnWhen();

            _facade.Show(_key, _viewModel);
        }

        [Test]
        public void should_call_show_on_view_model()
        {
            Expect.Call(_presenter.Show(_viewModel)).Return(_presenter);

            When();
        }
    }
}