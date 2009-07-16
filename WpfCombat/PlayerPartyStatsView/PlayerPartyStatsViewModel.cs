using System.Collections.Generic;
using CombatLibrary.CombatMembers;
using CombatLibrary.Events;
using WpfFoundation.ViewModels;

namespace WpfCombat.PlayerPartyStatsView
{
    public class PlayerPartyStatsViewModel : ViewModel
    {
        public PlayerPartyStatsViewModel(CombatStartedEvent e)
        {
            PartyMembers = e.Players;
        }

        public IEnumerable<IPlayerCombatMember> PartyMembers { get; private set; }
    }
}