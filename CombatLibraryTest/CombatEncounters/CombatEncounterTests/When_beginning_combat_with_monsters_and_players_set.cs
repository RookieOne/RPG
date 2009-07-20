using CombatLibrary.Events;
using CombatLibraryTest.CombatEncounters.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests
{
    [TestFixture]
    public class When_beginning_combat_with_monsters_and_players_set : NewCombatWithSinglePlayerAndSingleMonster
    {
        public override void OnWhen()
        {
            base.OnWhen();

            _combatEncounter.BeginCombat();
        }

        [Test]
        public void should_send_player_ready_for_action_events_for_each_player()
        {
            When();
            Assert.AreEqual(1, _eventAggregator.GetPublicationCount<PlayerReadyForActionEvent>());
        }
    }
}