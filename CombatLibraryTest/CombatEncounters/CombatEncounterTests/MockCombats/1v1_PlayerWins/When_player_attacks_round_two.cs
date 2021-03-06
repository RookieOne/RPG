﻿using CombatLibrary.Events;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests.MockCombats._1v1_PlayerWins
{
    [TestFixture]
    public class When_player_attacks_round_two : OneVsOne_PlayerWins
    {
        public override void OnWhen()
        {
            base.OnWhen();

            Round1();
            Round2();
        }

        [Test]
        public void all_monsters_should_be_dead()
        {
            When();
            Assert.IsTrue(_combatEncounter.AllMonstersAreDead());
        }

        [Test]
        public void all_players_should_be_alive()
        {
            When();
            Assert.IsFalse(_combatEncounter.AllPlayersAreDead());
        }

        [Test]
        public void should_not_recieve_monsters_win_message()
        {
            When();
            Assert.AreEqual(0, _eventAggregator.GetPublicationCount<MonstersWinEvent>());
        }

        [Test]
        public void should_recieve_players_win_message()
        {
            When();
            Assert.AreEqual(1, _eventAggregator.GetPublicationCount<PlayersWinEvent>());
        }
    }
}