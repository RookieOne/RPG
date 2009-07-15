using System.Collections.Generic;
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
            _presenters = new Dictionary<string, IPresenter>();
        }

        private static readonly Dictionary<string, IPresenter> _presenters;

        /// <summary>
        /// Registers the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="presenter">The presenter.</param>
        public static void Register(string key, IPresenter presenter)
        {
            _presenters.Add(key, presenter);
        }

        /// <summary>
        /// Shows the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public static IPresenter Show(string key, IViewModel viewModel)
        {
            IPresenter presenter;

            if (_presenters.TryGetValue(key, out presenter))
                presenter.Show(viewModel);

            return presenter;
        }
    }
}