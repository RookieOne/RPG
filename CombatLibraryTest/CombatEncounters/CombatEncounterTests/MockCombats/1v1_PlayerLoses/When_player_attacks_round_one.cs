using CombatLibrary.Events;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests.MockCombats._1v1_PlayerLoses
{
    [TestFixture]
    public class When_player_attacks_round_one : OneVsOne_PlayerLoses
    {
        public override void OnWhen()
        {
            base.OnWhen();

            Round1();
        }

        [Test]
        public void all_monsters_should_be_alive()
        {
            Assert.IsFalse(_combatEncounter.AllMonstersAreDead());
        }

        [Test]
        public void all_players_should_be_alive()
        {
            Assert.IsFalse(_combatEncounter.AllPlayersAreDead());
        }

        [Test]
        public void should_not_recieve_monsters_win_message()
        {
            Assert.AreEqual(0, _eventAggregator.GetPublicationCount<MonstersWinEvent>());
        }

        [Test]
        public void should_not_recieve_players_win_message()
        {
            Assert.AreEqual(0, _eventAggregator.GetPublicationCount<PlayersWinEvent>());
        }
    }
}