using System.Collections.Generic;
using System.Linq;
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
            _viewModelCache = new Dictionary<string, List<IViewModel>>();
        }

        private static readonly Dictionary<string, IPresenter> _presenters;
        private static readonly Dictionary<string, List<IViewModel>> _viewModelCache;

        /// <summary>
        /// Registers the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="presenter">The presenter.</param>
        public static void Register(string key, IPresenter presenter)
        {
            _presenters.Add(key, presenter);

            List<IViewModel> cachedViewModels;
            if (_viewModelCache.TryGetValue(key, out cachedViewModels))
            {
                cachedViewModels.ForEach(v => presenter.Show(v));
                _viewModelCache.Remove(key);
            }
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
            {
                presenter.Show(viewModel);
            }
            else
            {
                if (!_viewModelCache.ContainsKey(key))
                    _viewModelCache.Add(key, new List<IViewModel>());

                _viewModelCache[key].Add(viewModel);
            }

            return presenter;
        }
    }
}