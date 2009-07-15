using CombatLibrary.CombatMembers;
using FoundationTest.ContextSpecifications;

namespace CombatLibraryTest.CombatMembers.MonsterCombatMemberTests.Contexts
{
    public class NewMonster : WithEventing
    {
        protected MonsterCombatMember _monster;

        public override void Given()
        {
            base.Given();

            _monster = new MonsterCombatMember(10, "monster");
        }
    }
}