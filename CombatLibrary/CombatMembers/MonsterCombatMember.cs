using System.Collections.Generic;
using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatMembers
{
    /// <summary>
    /// Implements IMonsterCombatMember
    /// </summary>
    public class MonsterCombatMember : CombatMember, IMonsterCombatMember
    {
        public ITargetStrategy _targetStrategy;

        /// <summary>
        /// Gets a target.
        /// </summary>
        /// <param name="combatMembers">The combat members.</param>
        /// <returns></returns>
        public ITarget GetTarget(IEnumerable<ICombatMember> combatMembers)
        {
            return _targetStrategy.GetTarget(combatMembers);
        }

        /// <summary>
        /// Sets the target strategy.
        /// </summary>
        /// <param name="targetStrategy">The target strategy.</param>
        public void SetTargetStrategy(ITargetStrategy targetStrategy)
        {
            _targetStrategy = targetStrategy;
        }
    }
}