using System.Linq;
using CombatLibrary.CombatActions;
using CombatLibrary.CombatActionStrategies;
using CombatLibrary.CombatMembers;
using CombatLibrary.TargetStrategies;
using CombatLibraryTest.CombatMembers.MonsterCombatMemberTests.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatMembers.MonsterCombatMemberTests
{
    [TestFixture]
    public class When_getting_combat_action : NewMonsterWithTargets
    {
        protected ICombatAction _action;

        public override void OnWhen()
        {
            base.OnWhen();

            _monster.SetTargetStrategy(new RandomTargetStrategy());
            _monster.SetCombatActionStrategy(new RegularAttackStrategy());
            _action = _monster.GetCombatAction(_players.Cast<ICombatMember>());
        }

        [Test]
        public void should_not_return_null()
        {
            When();
            Assert.IsNotNull(_action);
        }
    }
}