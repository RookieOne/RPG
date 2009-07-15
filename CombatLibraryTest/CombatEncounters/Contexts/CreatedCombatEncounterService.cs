using CombatLibrary.CombatEncounters;
using FoundationTest.ContextSpecifications;

namespace CombatLibraryTest.CombatEncounters.Contexts
{
    public class CreatedCombatEncounterService : WithEventingAndMessaging
    {
        public override void Given()
        {
            base.Given();

            CombatEncounterService.Create();
        }
    }
}