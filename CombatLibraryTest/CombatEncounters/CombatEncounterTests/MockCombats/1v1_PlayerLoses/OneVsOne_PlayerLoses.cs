﻿using System.Collections.Generic;
using CombatLibrary.CombatActions;
using CombatLibrary.CombatActionStrategies;
using CombatLibrary.CombatMembers;
using CombatLibrary.Messages;
using CombatLibrary.TargetStrategies;
using CombatLibraryTest.CombatEncounters.Contexts;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests.MockCombats._1v1_PlayerLoses
{
    public class OneVsOne_PlayerLoses : NewCombatEncounter
    {
        protected MonsterCombatMember _monster;
        protected PlayerCombatMember _player;

        public override void Given()
        {
            base.Given();

            _player = new PlayerCombatMember(2, "player");
            _monster = new MonsterCombatMember(100, "monster")
                           .SetTargetStrategy(new RandomTargetStrategy())
                           .SetCombatActionStrategy(new RegularAttackStrategy()) as MonsterCombatMember;

            _combatEncounter.SetPlayers(new List<IPlayerCombatMember> {_player});
            _combatEncounter.AddMonsters(new List<IMonsterCombatMember> {_monster});
        }

        public void Round1()
        {
            ICombatAction action = new RegularAttackAction(5).SetTarget(_monster);
            var message = new PlayerActionMessage(_player, action);
            _combatEncounter.OnPlayerAction(message);
        }

        public void Round2()
        {
            ICombatAction action = new RegularAttackAction(5).SetTarget(_monster);
            var message = new PlayerActionMessage(_player, action);
            _combatEncounter.OnPlayerAction(message);
        }
    }
}