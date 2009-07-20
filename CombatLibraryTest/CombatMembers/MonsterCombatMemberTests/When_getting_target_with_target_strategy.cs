using System.Linq;
using CombatLibrary.CombatMembers;
using CombatLibrary.TargetStrategies;
using CombatLibraryTest.CombatMembers.MonsterCombatMemberTests.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatMembers.MonsterCombatMemberTests
{
    [TestFixture]
    public class When_getting_target_with_target_strategy : NewMonsterWithTargets
    {
        public override void OnWhen()
        {
            base.OnWhen();

            _monster.SetTargetStrategy(new RandomTargetStrategy());
            _target = _monster.GetTarget(_players.Cast<ICombatMember>());
        }

        [Test]
        public void should_not_return_null()
        {
            When();
            Assert.IsNotNull(_target);
        }
    }
}