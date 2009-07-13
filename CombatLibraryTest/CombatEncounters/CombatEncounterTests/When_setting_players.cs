using System.Collections.Generic;
using System.Linq;
using CombatLibrary.CombatMembers;
using CombatLibrary.Events;
using CombatLibraryTest.CombatEncounters.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests
{
    [TestFixture]
    public class When_setting_players : NewCombatEncounter
    {
        private List<PlayerCombatMember> _players;

        public override void When()
        {
            base.When();

            _players = new List<PlayerCombatMember>
                           {
                               new PlayerCombatMember(100),
                               new PlayerCombatMember(100)
                           };
            _combatEncounter.SetPlayers(_players.Cast<IPlayerCombatMember>());
        }

        [Test]
        public void should_set_players_in_combat_encounter()
        {
            Assert.AreEqual(_players.Count, _combatEncounter._players.Count());
        }

        [Test]
        public void should_be_the_same_players()
        {
            foreach(var player in _players)
                Assert.IsTrue(_combatEncounter._players.Contains(player));
        }

        [Test]
        public void should_send_player_ready_for_action_events_for_each_player()
        {
            Assert.AreEqual(2, _eventAggregator.GetPublicationCount<PlayerReadyForActionEvent>());
        }
    }
}