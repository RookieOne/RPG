using CombatLibrary.CombatMembers;

namespace CombatLibrary.Events
{
    public class CombatDeathEvent
    {
        public CombatDeathEvent(ICombatMember combatMember)
        {
            MemberThatDied = combatMember;
        }

        public ICombatMember MemberThatDied { get; private set; }
    }
}