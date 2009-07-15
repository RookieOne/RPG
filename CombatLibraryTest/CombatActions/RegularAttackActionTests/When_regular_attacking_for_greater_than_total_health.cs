using CombatLibrary.CombatActions;
using CombatLibrary.Events;
using CombatLibraryTest.CombatActions.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatActions.RegularAttackActionTests
{
    [TestFixture]
    public class When_regular_attacking_for_greater_than_total_health : SinglePlayerWith100Health
    {
        public override void When()
        {
            base.When();

            new RegularAttackAction(150)
                .SetTarget(_singlePlayer)
                .Execute();
        }

        [Test]
        public void should_kill_player()
        {
            Assert.IsTrue(_singlePlayer.IsDead);
        }

        [Test]
        public void should_take_player_health_to_zerp()
        {
            Assert.AreEqual(0, _singlePlayer.Health);
        }

        [Test]
        public void should_publish_damage_event()
        {
            Assert.AreEqual(1, _eventAggregator.GetPublicationCount<DamageEvent>());
        }
    }
}