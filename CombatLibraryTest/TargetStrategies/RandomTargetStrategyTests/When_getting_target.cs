using CombatLibrary.TargetStrategies;
using CombatLibraryTest.TargetStrategies.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.TargetStrategies.RandomTargetStrategyTests
{
    [TestFixture]
    public class When_getting_target : SimplePartyOfFour
    {
        private ITarget _target;

        public override void OnWhen()
        {
            base.OnWhen();

            _target = new RandomTargetStrategy().GetTarget(_combatMembers);
        }

        [Test]
        public void should_be_a_single_target()
        {
            When();
            Assert.IsInstanceOfType(typeof (SingleTarget), _target);
        }

        [Test]
        public void should_return_one_of_the_combat_members()
        {
            When();

            var singleTarget = _target as SingleTarget;

            Assert.IsTrue(_combatMembers.Contains(singleTarget.CombatMember));
        }
    }
}