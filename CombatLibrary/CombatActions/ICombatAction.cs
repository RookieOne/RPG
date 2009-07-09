using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatActions
{
    public interface ICombatAction
    {
        ICombatAction SetTarget(ITarget target);
        ICombatAction Execute();
    }
}