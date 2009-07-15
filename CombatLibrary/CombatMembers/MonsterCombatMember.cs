using System.Collections.Generic;
using CombatLibrary.CombatActions;
using CombatLibrary.CombatActionStrategies;
using CombatLibrary.TargetStrategies;

namespace CombatLibrary.CombatMembers
{
    /// <summary>
    /// Implements IMonsterCombatMember
    /// </summary>
    public class MonsterCombatMember : CombatMember, IMonsterCombatMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterCombatMember"/> class.
        /// </summary>
        /// <param name="health">The health.</param>
        /// <param name="name">The name.</param>
        public MonsterCombatMember(int health, string name)
            : base(name)
        {
            AddHealth(health);
        }

        public ICombatActionStrategy _combatActionStrategy;
        public ITargetStrategy _targetStrategy;

        /// <summary>
        /// Gets the combat action.
        /// </summary>
        /// <returns></returns>
        public ICombatAction GetCombatAction(IEnumerable<ICombatMember> combatMembers)
        {
            if (_combatActionStrategy == null
                || _targetStrategy == null)
                return null;

            ITarget target = GetTarget(combatMembers);

            return _combatActionStrategy.GetCombatAction(target);
        }

        /// <summary>
        /// Gets a target.
        /// </summary>
        /// <param name="combatMembers">The combat members.</param>
        /// <returns></returns>
        public ITarget GetTarget(IEnumerable<ICombatMember> combatMembers)
        {
            if (_targetStrategy == null)
                return null;

            return _targetStrategy.GetTarget(combatMembers);
        }

        /// <summary>
        /// Sets the combat action strategy.
        /// </summary>
        /// <param name="combatActionStrategy">The combat action strategy.</param>
        public IMonsterCombatMember SetCombatActionStrategy(ICombatActionStrategy combatActionStrategy)
        {
            _combatActionStrategy = combatActionStrategy;
            return this;
        }

        /// <summary>
        /// Sets the target strategy.
        /// </summary>
        /// <param name="targetStrategy">The target strategy.</param>
        public IMonsterCombatMember SetTargetStrategy(ITargetStrategy targetStrategy)
        {
            _targetStrategy = targetStrategy;
            return this;
        }
    }
}