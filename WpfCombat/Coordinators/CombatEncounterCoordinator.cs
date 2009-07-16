using CombatLibrary.Events;
using Foundation.Eventing;
using WpfCombat.CombatEncounterView;
using WpfFoundation.Presenters;

namespace WpfCombat.Coordinators
{
    public class CombatEncounterCoordinator
    {
        public CombatEncounterCoordinator()
        {
            EventAggregator.Subscribe<CombatStartedEvent>(OnCombatStarted);
        }

        private void OnCombatStarted(CombatStartedEvent e)
        {
            Presenter.Show(AppPresenters.Shell, new CombatEncounterViewModel(e));
        }
    }
}