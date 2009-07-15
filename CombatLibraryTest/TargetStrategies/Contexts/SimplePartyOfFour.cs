using System.Collections.Generic;
using CombatLibrary.CombatMembers;
using FoundationTest.ContextSpecifications;

namespace CombatLibraryTest.TargetStrategies.Contexts
{
    public class SimplePartyOfFour : ContextSpecification
    {
        protected List<ICombatMember> _combatMembers;

        public override void Given()
        {
            base.Given();

            _combatMembers = new List<ICombatMember>();
            _combatMembers.Add(new PlayerCombatMember(100, "player1"));
            _combatMembers.Add(new PlayerCombatMember(100, "player2"));
            _combatMembers.Add(new PlayerCombatMember(100, "player3"));
            _combatMembers.Add(new PlayerCombatMember(100, "player4"));
        }
    }
}