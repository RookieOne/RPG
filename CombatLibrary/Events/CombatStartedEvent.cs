using System.Collections.Generic;
using CombatLibrary.CombatMembers;

namespace CombatLibrary.Events
{
    /// <summary>
    /// Combat Started Event
    /// </summary>
    public class CombatStartedEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombatStartedEvent"/> class.
        /// </summary>
        /// <param name="players">The players.</param>
        /// <param name="monsters">The monsters.</param>
        public CombatStartedEvent(IEnumerable<IPlayerCombatMember> players,
                                  IEnumerable<IMonsterCombatMember> monsters)
        {
            Players = players;
            Monsters = monsters;
        }

        /// <summary>
        /// Gets or sets the monsters.
        /// </summary>
        /// <value>The monsters.</value>
        public IEnumerable<IMonsterCombatMember> Monsters { get; private set; }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>The players.</value>
        public IEnumerable<IPlayerCombatMember> Players { get; private set; }
    }
}