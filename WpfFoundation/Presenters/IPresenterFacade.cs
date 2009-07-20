using WpfFoundation.ViewModels;

namespace WpfFoundation.Presenters
{
    public interface IPresenterFacade
    {
        /// <summary>
        /// Registers the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="presenter">The presenter.</param>
        void Register(string key, IPresenter presenter);

        /// <summary>
        /// Shows the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        IPresenter Show(string key, IViewModel viewModel);
    }
}