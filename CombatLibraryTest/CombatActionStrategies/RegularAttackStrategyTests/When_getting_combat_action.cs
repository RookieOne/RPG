using CombatLibrary.CombatActions;
using CombatLibrary.CombatActionStrategies;
using FoundationTest.ContextSpecifications;
using NUnit.Framework;

namespace CombatLibraryTest.CombatActionStrategies.RegularAttackStrategyTests
{
    [TestFixture]
    public class When_getting_combat_action : ContextSpecification
    {
        private ICombatAction _action;

        public override void When()
        {
            base.When();

            _action = new RegularAttackStrategy().GetCombatAction(null);
        }

        [Test]
        public void should_return_a_regular_attack()
        {
            Assert.IsInstanceOfType(typeof(RegularAttackAction), _action);
        }
    }
}