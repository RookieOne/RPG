using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfFoundation.Presenters
{
    /// <summary>
    /// Assign Presenter Attached Dependency Property
    /// Allows registering of presenters using xaml
    /// </summary>
    public static class AssignPresenter
    {
        public static readonly DependencyProperty NameProperty = DependencyProperty.RegisterAttached("Name",
                                                                                                     typeof (string),
                                                                                                     typeof (
                                                                                                         AssignPresenter
                                                                                                         ),
                                                                                                     new PropertyMetadata
                                                                                                         (OnNameChange));


        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        public static string GetName(DependencyObject d)
        {
            return (string) d.GetValue(NameProperty);
        }

        /// <summary>
        /// Called when [name change].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var contentControl = d as ContentControl;
            if (contentControl != null)
            {
                Presenter.Register(GetName(d), new ContentControlPresenter(contentControl));
            }
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="value">The value.</param>
        public static void SetName(DependencyObject d, string value)
        {
            d.SetValue(NameProperty, value);
        }
    }
}