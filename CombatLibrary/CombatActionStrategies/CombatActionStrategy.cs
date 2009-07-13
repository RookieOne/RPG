using CombatLibrary.CombatActions;
using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatActionStrategies
{
    /// <summary>
    /// Base Combat Action Strategy
    /// </summary>
    public abstract class CombatActionStrategy : ICombatActionStrategy
    {
        /// <summary>
        /// Builds the combat action.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public abstract ICombatAction BuildCombatAction(ITarget target);

        /// <summary>
        /// Gets the combat action.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public ICombatAction GetCombatAction(ITarget target)
        {
            return BuildCombatAction(target).SetTarget(target);
        }
    }
}