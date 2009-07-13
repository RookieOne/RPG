using CombatLibrary.CombatActions;
using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatActionStrategies
{
    /// <summary>
    /// Regular Attack Strategy
    /// </summary>
    public class RegularAttackStrategy : CombatActionStrategy
    {
        /// <summary>
        /// Gets the combat action.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override ICombatAction BuildCombatAction(ITarget target)
        {
            return new RegularAttackAction(1);
        }
    }
}