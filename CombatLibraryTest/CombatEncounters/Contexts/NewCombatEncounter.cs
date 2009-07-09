using CombatLibrary.CombatEncounters;
using FoundationTest.ContextSpecifications;

namespace CombatLibraryTest.CombatEncounters.Contexts
{
    public class NewCombatEncounter : WithEventing
    {
        protected CombatEncounter _combatEncounter;

        public override void Given()
        {
            base.Given();

            _combatEncounter = new CombatEncounter();
        }
    }
}