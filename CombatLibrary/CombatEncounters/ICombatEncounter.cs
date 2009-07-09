using System.Collections.Generic;
using CombatLibrary.CombatMembers;

namespace CombatLibrary.CombatEncounters
{
    /// <summary>
    /// Interface for Combat Encounter
    /// </summary>
    public interface ICombatEncounter
    {
        /// <summary>
        /// Adds the monsters to combat encounter.
        /// </summary>
        /// <param name="monsters">The monsters.</param>
        /// <returns></returns>
        ICombatEncounter AddMonsters(IEnumerable<IMonsterCombatMember> monsters);

        /// <summary>
        /// Sets the players.
        /// </summary>
        /// <param name="players">The players.</param>
        /// <returns></returns>
        ICombatEncounter SetPlayers(IEnumerable<PlayerCombatMember> players);
    }
}