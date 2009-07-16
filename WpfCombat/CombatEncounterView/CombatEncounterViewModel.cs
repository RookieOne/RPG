using CombatLibrary.Events;
using WpfCombat.PlayerPartyStatsView;
using WpfCombat.Presenters;
using WpfFoundation.Presenters;
using WpfFoundation.ViewModels;

namespace WpfCombat.CombatEncounterView
{
    public class CombatEncounterViewModel : ViewModel
    {
        internal CombatEncounterViewModel(CombatStartedEvent e)
        {
            Presenter.Show(CombatPresenters.PlayerPartyStats, new PlayerPartyStatsViewModel(e));
        }
    }
}