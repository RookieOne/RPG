using CombatLibrary.CombatActions;
using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatActionStrategies
{
    /// <summary>
    /// Interface for Combat Action Strategy
    /// </summary>
    public interface ICombatActionStrategy
    {
        /// <summary>
        /// Gets the combat action.
        /// </summary>
        /// <returns></returns>
        ICombatAction GetCombatAction(ITarget target);
    }
}