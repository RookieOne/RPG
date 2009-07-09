using System.Collections.Generic;
using CombatLibrary.CombatMembers;
using CombatLibrary.Events;
using Foundation.Eventing;

namespace CombatLibrary.CombatEncounters
{
    /// <summary>
    /// Implements ICombat Encounter
    /// </summary>
    public class CombatEncounter : ICombatEncounter
    {
        public List<IMonsterCombatMember> _monsters;
        public IEnumerable<PlayerCombatMember> _players;

        /// <summary>
        /// Initializes a new instance of the <see cref="CombatEncounter"/> class.
        /// </summary>
        public CombatEncounter()
        {
            _monsters = new List<IMonsterCombatMember>();
        }

        /// <summary>
        /// Adds the monsters to combat encounter.
        /// </summary>
        /// <param name="monsters">The monsters.</param>
        /// <returns></returns>
        public ICombatEncounter AddMonsters(IEnumerable<IMonsterCombatMember> monsters)
        {
            _monsters.AddRange(monsters);
            return this;
        }

        public bool IsFinished()
        {
            bool allMonstersAreDead = true;
            foreach (var monster in _monsters)
                if (!monster.IsDead)
                {
                    allMonstersAreDead = false;
                    break;
                }

            bool allPlayersAreDead = true;
            foreach (var player in _players)
                if (!player.IsDead)
                {
                    allPlayersAreDead = false;
                    break;
                }

            return allMonstersAreDead || allPlayersAreDead;
        }

        /// <summary>
        /// Sets the players.
        /// </summary>
        /// <param name="players">The players.</param>
        /// <returns></returns>
        public ICombatEncounter SetPlayers(IEnumerable<PlayerCombatMember> players)
        {
            _players = players;

            foreach (var player in players)
            {
                EventAggregator.Publish(new PlayerReadyForActionEvent(player));
            }
            return this;
        }
    }
}