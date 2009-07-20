using WpfFoundation.ViewModels;

namespace WpfFoundation.Presenters
{
    /// <summary>
    /// Presenter
    /// </summary>
    public static class Presenter
    {
        /// <summary>
        /// Initializes the <see cref="Presenter"/> class.
        /// </summary>
        static Presenter()
        {
            _facade = new DefaultPresenterFacade();
        }

        private static readonly IPresenterFacade _facade;

        /// <summary>
        /// Registers the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="presenter">The presenter.</param>
        public static void Register(string key, IPresenter presenter)
        {
            _facade.Register(key, presenter);
        }

        /// <summary>
        /// Shows the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public static IPresenter Show(string key, IViewModel viewModel)
        {
            return _facade.Show(key, viewModel);
        }
    }
}