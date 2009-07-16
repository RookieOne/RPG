using System.Reflection;
using System.Windows;
using CombatLibrary.CombatEncounters;
using Foundation.Eventing;
using Foundation.Messaging;
using WpfCombat.CombatEncounterView;
using WpfCombat.Coordinators;
using WpfFoundation.Loaders;

namespace WpfRPGShell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CombatEncounterCoordinator _coordinator;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MessageBroker.SetMessageBroker(new DefaultMessageBroker());
            EventAggregator.SetAggregator(new DefaultEventAggregator());

            ResourceDictionaryLoader.Create()
                .LoadResourceDictionaries(Assembly.GetAssembly(typeof (CombatEncounterViewModel)));

            CombatEncounterService.Create();

            _coordinator = new CombatEncounterCoordinator();
        }
    }
}