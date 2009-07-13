using System.Linq;
using CombatLibrary.CombatActions;
using CombatLibrary.CombatMembers;
using CombatLibrary.TargetStrategies;
using CombatLibraryTest.CombatMembers.MonsterCombatMemberTests.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatMembers.MonsterCombatMemberTests
{
    [TestFixture]
    public class When_getting_combat_action_without_combat_strategy : NewMonsterWithTargets
    {
        protected ICombatAction _action;

        public override void When()
        {
            base.When();

            _monster.SetTargetStrategy(new RandomTargetStrategy());
            _action = _monster.GetCombatAction(_players.Cast<ICombatMember>());
        }

        [Test]
        public void should_return_null()
        {
            Assert.IsNull(_action);
        }
    }
}