using System;
using System.Collections.Generic;
using System.Linq;
using CombatLibrary.CombatMembers;

namespace CombatLibrary.TargetStrategies
{
    public class RandomTargetStrategy : ITargetStrategy
    {
        public ITarget GetTarget(IEnumerable<ICombatMember> combatMembers)
        {
            var index = new Random().Next(0, combatMembers.Count());

            var combatMember = combatMembers.ToList()[index];

            return new SingleTarget(combatMember);
        }
    }
}