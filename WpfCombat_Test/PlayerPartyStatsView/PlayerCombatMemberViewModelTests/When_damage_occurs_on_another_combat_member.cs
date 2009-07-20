using CombatLibrary.CombatMembers;
using CombatLibrary.Events;
using NUnit.Framework;

namespace WpfCombat_Test.PlayerPartyStatsView.PlayerCombatMemberViewModelTests
{
    [TestFixture]
    public class When_damage_occurs_on_another_combat_member : NewPlayerCombatMemberViewModel
    {
        protected DamageEvent _event;

        public override void OnWhen()
        {
            base.OnWhen();

            var combatMember = new PlayerCombatMember(100, "Other Player");
            _event = new DamageEvent(combatMember, 10);
            _eventAggregator.Publish(_event);
        }

        [Test]
        public void should_not_take_damage()
        {
            When();
            Assert.AreEqual(_viewModel.TotalHealth, _viewModel.CurrentHealth);
        }
    }
}