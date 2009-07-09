using CombatLibrary.CombatMembers;
using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatActions
{
    public static class CombatActionExtensions
    {
        public static ICombatAction SetTarget(this ICombatAction combatAction, ICombatMember combatMember)
        {
            return combatAction.SetTarget(new SingleTarget(combatMember));
        }
    }
}