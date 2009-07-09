using CombatLibrary.CombatMembers;

namespace CombatLibrary.TargetStrategies
{
    public class SingleTarget : ITarget
    {
        public SingleTarget(ICombatMember combatMember)
        {
            CombatMember = combatMember;
        }

        public ICombatMember CombatMember { get; private set; }

        public void TakeDamage(int damage)
        {
            CombatMember.TakeDamage(damage);
        }
    }
}