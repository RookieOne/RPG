using WpfFoundation.ViewModels;

namespace WpfFoundation.Presenters
{
    /// <summary>
    /// Interface for presenter
    /// </summary>
    public interface IPresenter
    {
        /// <summary>
        /// Shows the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        IPresenter Show(IViewModel viewModel);
    }
}