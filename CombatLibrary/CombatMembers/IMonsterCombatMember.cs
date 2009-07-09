using System.Collections.Generic;
using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatMembers
{
    /// <summary>
    /// Interface for Monster Combat Member
    /// </summary>
    public interface IMonsterCombatMember : ICombatMember
    {
        /// <summary>
        /// Sets the target strategy.
        /// </summary>
        /// <param name="targetStrategy">The target strategy.</param>
        void SetTargetStrategy(ITargetStrategy targetStrategy);

        /// <summary>
        /// Gets a target.
        /// </summary>
        /// <param name="combatMembers">The combat members.</param>
        /// <returns></returns>
        ITarget GetTarget(IEnumerable<ICombatMember> combatMembers);
    }
}