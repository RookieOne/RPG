using System.Windows;
using Foundation.Eventing;
using Foundation.Messaging;

namespace WpfRPGShell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MessageBroker.SetMessageBroker(new DefaultMessageBroker());
            EventAggregator.SetAggregator(new DefaultEventAggregator());
        }
    }
}