﻿using CombatLibrary.CombatActions;
using CombatLibrary.CombatMembers;
using CombatLibrary.Messages;
using CombatLibraryTest.CombatEncounters.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests
{
    [TestFixture]
    public class When_receiving_player_action : NewCombatWithPlayersSet
    {
        private PlayerActionMessage _message;
        private PlayerCombatMember _player;

        public override void OnWhen()
        {
            base.OnWhen();

            _player = _players[0];
            var action = new RegularAttackAction(30);
            _message = new PlayerActionMessage(_player, action);

            _combatEncounter.OnPlayerAction(_message);
        }

        [Test]
        public void should_add_player_action_message_to_list()
        {
            When();
            Assert.IsTrue(_combatEncounter._playerActions.Contains(_message));
        }

        [Test]
        public void should_only_have_one_player_action_message_in_list()
        {
            When();
            Assert.AreEqual(1, _combatEncounter._playerActions.Count);
        }
    }
}