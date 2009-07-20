using CombatLibrary.CombatActions;
using CombatLibrary.Events;
using CombatLibraryTest.CombatActions.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatActions.RegularAttackActionTests
{
    [TestFixture]
    public class When_regular_attacking_for_less_than_total_health : SinglePlayerWith100Health
    {
        public override void OnWhen()
        {
            base.OnWhen();

            new RegularAttackAction(75)
                .SetTarget(_singlePlayer)
                .Execute();
        }

        [Test]
        public void should_damage_player_by_attack_power()
        {
            When();
            Assert.AreEqual(25, _singlePlayer.Health);
        }

        [Test]
        public void should_not_kill_player()
        {
            When();
            Assert.IsFalse(_singlePlayer.IsDead);
        }

        [Test]
        public void should_publish_damage_event()
        {
            When();
            Assert.AreEqual(1, _eventAggregator.GetPublicationCount<DamageEvent>());
        }
    }
}