using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatActions
{
    public abstract class CombatAction : ICombatAction
    {
        protected ITarget _target;

        public ICombatAction SetTarget(ITarget target)
        {
            _target = target;
            return this;
        }

        protected abstract void OnExecute();

        public ICombatAction Execute()
        {
            if (_target != null)
                OnExecute();

            return this;
        }
    }
}