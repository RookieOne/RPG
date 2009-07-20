using CombatLibrary.CombatMembers;
using FoundationTest.ContextSpecifications;
using WpfCombat.PlayerPartyStatsView;

namespace WpfCombat_Test.PlayerPartyStatsView.PlayerCombatMemberViewModelTests
{
    public class NewPlayerCombatMemberViewModel : WithEventing
    {
        protected PlayerCombatMember _player;
        protected PlayerCombatMemberViewModel _viewModel;

        public override void Given()
        {
            base.Given();

            _player = new PlayerCombatMember(100, "Test");
            _viewModel = new PlayerCombatMemberViewModel(_player);
        }
    }
}