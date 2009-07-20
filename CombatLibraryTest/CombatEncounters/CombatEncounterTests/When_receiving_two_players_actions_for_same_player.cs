using CombatLibrary.CombatActions;
using CombatLibrary.CombatMembers;
using CombatLibrary.Messages;
using CombatLibraryTest.CombatEncounters.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests
{
    [TestFixture]
    public class When_receiving_two_players_actions_for_same_player : NewCombatWithPlayersSet
    {
        private PlayerActionMessage _message1;
        private PlayerActionMessage _message2;
        private PlayerCombatMember _player;

        public override void OnWhen()
        {
            base.OnWhen();

            _player = _players[0];

            var action1 = new RegularAttackAction(30);
            _message1 = new PlayerActionMessage(_player, action1);

            var action2 = new RegularAttackAction(30);
            _message2 = new PlayerActionMessage(_player, action2);

            _combatEncounter.OnPlayerAction(_message1);
            _combatEncounter.OnPlayerAction(_message2);
        }

        [Test]
        public void should_not_have_first_player_action_in_list()
        {
            When();
            Assert.IsFalse(_combatEncounter._playerActions.Contains(_message1));
        }

        [Test]
        public void should_only_have_one_player_action_message_in_list()
        {
            When();
            Assert.AreEqual(1, _combatEncounter._playerActions.Count);
        }

        [Test]
        public void should_replace_player_action_message_in_list()
        {
            When();
            Assert.IsTrue(_combatEncounter._playerActions.Contains(_message2));
        }
    }
}