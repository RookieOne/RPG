using CombatLibrary.Events;
using NUnit.Framework;

namespace WpfCombat_Test.PlayerPartyStatsView.PlayerCombatMemberViewModelTests
{
    [TestFixture]
    public class When_player_receives_damage : NewPlayerCombatMemberViewModel
    {
        protected DamageEvent _event;

        public override void OnWhen()
        {
            base.OnWhen();

            _event = new DamageEvent(_player, 10);
            _eventAggregator.Publish(_event);
        }

        [Test]
        public void should_take_damage()
        {
            When();
            Assert.AreNotEqual(_viewModel.TotalHealth, _viewModel.CurrentHealth);
        }

        [Test]
        public void should_take_damage_by_same_amount_on_event()
        {
            When();
            Assert.AreEqual(_viewModel.TotalHealth - _event.Damage, _viewModel.CurrentHealth);
        }
    }
}