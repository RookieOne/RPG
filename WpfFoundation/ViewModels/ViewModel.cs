using System.ComponentModel;

namespace WpfFoundation.ViewModels
{
    /// <summary>
    /// Base abstract view model
    /// </summary>
    public abstract class ViewModel : IViewModel
    {
        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}