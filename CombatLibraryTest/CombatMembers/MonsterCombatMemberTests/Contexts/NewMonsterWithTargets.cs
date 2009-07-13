using System.Collections.Generic;
using CombatLibrary.CombatMembers;
using CombatLibrary.TargetStrategies;

namespace CombatLibraryTest.CombatMembers.MonsterCombatMemberTests.Contexts
{
    public class NewMonsterWithTargets : NewMonster
    {
        protected List<PlayerCombatMember> _players;
        protected ITarget _target;

        public override void Given()
        {
            base.Given();

            _players = new List<PlayerCombatMember>
                           {
                               new PlayerCombatMember(10)
                           };
        }
    }
}