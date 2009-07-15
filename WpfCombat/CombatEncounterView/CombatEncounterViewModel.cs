using CombatLibrary.Events;
using Foundation.Eventing;
using WpfFoundation.Presenters;
using WpfFoundation.ViewModels;

namespace WpfCombat.CombatEncounterView
{
    public class CombatEncounterViewModel : ViewModel
    {
        static CombatEncounterViewModel()
        {
            EventAggregator.Subscribe<CombatStartedEvent>(OnCombatStarted);
        }

        private CombatEncounterViewModel(CombatStartedEvent e)
        {
        }

        private static void OnCombatStarted(CombatStartedEvent e)
        {
            Presenter.Show(Presenters.Shell, new CombatEncounterViewModel(e));
        }
    }
}