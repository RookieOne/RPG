using System.Windows.Controls;
using WpfFoundation.ViewModels;

namespace WpfFoundation.Presenters
{
    /// <summary>
    /// Content Control Presenter
    /// </summary>
    public class ContentControlPresenter : IPresenter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentControlPresenter"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        public ContentControlPresenter(ContentControl control)
        {
            _control = control;
        }

        private readonly ContentControl _control;

        /// <summary>
        /// Shows the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public IPresenter Show(IViewModel viewModel)
        {
            if (_control == null)
                return this;

            _control.Content = viewModel;
            return this;
        }
    }
}