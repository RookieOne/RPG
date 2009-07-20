using CombatLibrary.CombatMembers;
using FoundationTest.ContextSpecifications;
using NUnit.Framework;
using WpfCombat.PlayerPartyStatsView;

namespace WpfCombat_Test.PlayerPartyStatsView.PlayerCombatMemberViewModelTests
{
    [TestFixture]
    public class When_creating_view_model : ContextSpecification
    {
        private PlayerCombatMember _player;
        private PlayerCombatMemberViewModel _viewModel;

        public override void OnWhen()
        {
            base.OnWhen();

            _player = new PlayerCombatMember(100, "Test");
            _viewModel = new PlayerCombatMemberViewModel(_player);
        }

        [Test]
        public void should_set_current_health_to_players_health()
        {
            When();
            Assert.AreEqual(_player.Health, _viewModel.CurrentHealth);
        }

        [Test]
        public void should_set_total_health_to_players_health()
        {
            When();
            Assert.AreEqual(_player.Health, _viewModel.TotalHealth);
        }

        [Test]
        public void should_set_name_to_players_name()
        {
            When();
            Assert.AreEqual(_player.Name, _viewModel.Name);
        }
    }
}