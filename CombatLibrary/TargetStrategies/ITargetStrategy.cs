using System.Collections.Generic;
using CombatLibrary.CombatMembers;

namespace CombatLibrary.TargetStrategies
{
    public interface ITargetStrategy
    {
        ITarget GetTarget(IEnumerable<ICombatMember> combatMembers);
    }
}