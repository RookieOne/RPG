using System.Collections.Generic;
using CombatLibrary.CombatActionStrategies;
using CombatLibrary.CombatMembers;
using CombatLibrary.TargetStrategies;

namespace CombatLibraryTest.CombatEncounters.Contexts
{
    public class NewCombatWithSinglePlayerAndSingleMonster : NewCombatEncounter
    {
        protected MonsterCombatMember _monster;
        protected PlayerCombatMember _player;

        public override void Given()
        {
            base.Given();

            _player = new PlayerCombatMember(10);
            _monster = new MonsterCombatMember(10)
                .SetTargetStrategy(new RandomTargetStrategy())
                .SetCombatActionStrategy(new RegularAttackStrategy()) as MonsterCombatMember;

            _combatEncounter.SetPlayers(new List<IPlayerCombatMember> {_player});
            _combatEncounter.AddMonsters(new List<IMonsterCombatMember> {_monster});
        }
    }
}