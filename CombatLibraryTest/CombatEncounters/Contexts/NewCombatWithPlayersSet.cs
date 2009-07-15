using System.Collections.Generic;
using System.Linq;
using CombatLibrary.CombatMembers;

namespace CombatLibraryTest.CombatEncounters.Contexts
{
    public class NewCombatWithPlayersSet : NewCombatEncounter
    {
        protected List<PlayerCombatMember> _players;

        public override void Given()
        {
            base.Given();

            _players = new List<PlayerCombatMember>();
            _players.Add(new PlayerCombatMember(10, "player1"));
            _players.Add(new PlayerCombatMember(10, "player2"));

            _combatEncounter.SetPlayers(_players.Cast<IPlayerCombatMember>());
        }
    }
}