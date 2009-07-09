using CombatLibrary.TargetStrategies;
using CombatLibraryTest.CombatMembers.MonsterCombatMemberTests.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatMembers.MonsterCombatMemberTests
{
    [TestFixture]
    public class When_setting_target_strategy : NewMonster
    {
        private RandomTargetStrategy _targetStrategy;

        public override void When()
        {
            base.When();

            _targetStrategy = new RandomTargetStrategy();
            _monster.SetTargetStrategy(_targetStrategy);
        }

        [Test]
        public void should_set_target_strategy()
        {
            Assert.AreEqual(_targetStrategy, _monster._targetStrategy);
        }
    }
}