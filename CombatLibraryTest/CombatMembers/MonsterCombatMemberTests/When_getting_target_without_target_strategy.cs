using CombatLibrary.TargetStrategies;
using CombatLibraryTest.CombatMembers.MonsterCombatMemberTests.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatMembers.MonsterCombatMemberTests
{
    [TestFixture]
    public class When_getting_target_without_target_strategy : NewMonster
    {
        private ITarget _target;

        public override void OnWhen()
        {
            base.OnWhen();

            _target = _monster.GetTarget(null);
        }

        [Test]
        public void should_return_null()
        {
            When();
            Assert.IsNull(_target);
        }
    }
}