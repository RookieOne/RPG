using CombatLibrary.CombatActions;
using CombatLibrary.Events;
using CombatLibrary.Messages;
using CombatLibraryTest.CombatEncounters.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests
{
    [TestFixture]
    public class When_recieved_all_player_actions : NewCombatWithSinglePlayerAndSingleMonster
    {
        public override void When()
        {
            base.When();

            var action = new RegularAttackAction(1).SetTarget(_monster);
            var message = new PlayerActionMessage(_player, action);

            _combatEncounter.OnPlayerAction(message);
        }

        [Test]
        public void should_begin_round()
        {
            Assert.AreEqual(1, _eventAggregator.GetPublicationCount<RoundBeganEvent>());
        }

        [Test]
        public void should_execute_and_end_round()
        {
            Assert.AreEqual(1, _eventAggregator.GetPublicationCount<RoundEndEvent>());
        }
    }
}