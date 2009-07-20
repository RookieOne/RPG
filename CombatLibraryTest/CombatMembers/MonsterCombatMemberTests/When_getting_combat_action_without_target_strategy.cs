using System.Linq;
using CombatLibrary.CombatActions;
using CombatLibrary.CombatActionStrategies;
using CombatLibrary.CombatMembers;
using CombatLibraryTest.CombatMembers.MonsterCombatMemberTests.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatMembers.MonsterCombatMemberTests
{
    [TestFixture]
    public class When_getting_combat_action_without_target_strategy : NewMonsterWithTargets
    {
        protected ICombatAction _action;

        public override void OnWhen()
        {
            base.OnWhen();

            _monster.SetCombatActionStrategy(new RegularAttackStrategy());
            _action = _monster.GetCombatAction(_players.Cast<ICombatMember>());
        }

        [Test]
        public void should_return_null()
        {
            When();
            Assert.IsNull(_action);
        }
    }
}