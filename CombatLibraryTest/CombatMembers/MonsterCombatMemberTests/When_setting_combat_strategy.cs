using CombatLibrary.CombatActionStrategies;
using CombatLibraryTest.CombatMembers.MonsterCombatMemberTests.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatMembers.MonsterCombatMemberTests
{
    [TestFixture]
    public class When_setting_combat_strategy : NewMonster
    {
        private RegularAttackStrategy _combatStrategy;

        public override void OnWhen()
        {
            base.OnWhen();

            _combatStrategy = new RegularAttackStrategy();
            _monster.SetCombatActionStrategy(_combatStrategy);
        }

        [Test]
        public void should_set_combat_strategy()
        {
            When();
            Assert.AreEqual(_combatStrategy, _monster._combatActionStrategy);
        }
    }
}