using System.Collections.Generic;
using CombatLibrary.CombatActions;
using CombatLibrary.CombatActionStrategies;
using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatMembers
{
    /// <summary>
    /// Interface for Monster Combat Member
    /// </summary>
    public interface IMonsterCombatMember : ICombatMember
    {
        /// <summary>
        /// Gets the combat action.
        /// </summary>
        /// <returns></returns>
        ICombatAction GetCombatAction(IEnumerable<ICombatMember> combatMembers);

        /// <summary>
        /// Sets the combat action strategy.
        /// </summary>
        /// <param name="combatActionStrategy">The combat action strategy.</param>
        IMonsterCombatMember SetCombatActionStrategy(ICombatActionStrategy combatActionStrategy);

        /// <summary>
        /// Sets the target strategy.
        /// </summary>
        /// <param name="targetStrategy">The target strategy.</param>
        IMonsterCombatMember SetTargetStrategy(ITargetStrategy targetStrategy);
    }
}