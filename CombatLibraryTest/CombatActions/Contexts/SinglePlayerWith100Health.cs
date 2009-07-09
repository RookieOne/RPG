using CombatLibrary.CombatMembers;
using FoundationTest.ContextSpecifications;

namespace CombatLibraryTest.CombatActions.Contexts
{
    public class SinglePlayerWith100Health : ContextSpecification
    {
        protected PlayerCombatMember _singlePlayer;

        public override void Given()
        {
            base.Given();

            _singlePlayer = new PlayerCombatMember(100);            
        }
    }
}