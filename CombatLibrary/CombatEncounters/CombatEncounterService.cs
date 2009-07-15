using CombatLibrary.Events;
using CombatLibrary.Messages;
using Foundation.Eventing;
using Foundation.Messaging;

namespace CombatLibrary.CombatEncounters
{
    /// <summary>
    /// Combat Encounter Service is responsible for starting combat encounters
    /// upon recieving a Start Combat Message
    /// </summary>
    public class CombatEncounterService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombatEncounterService"/> class.
        /// </summary>
        private CombatEncounterService()
        {
            MessageBroker.Register<StartCombatMessage>(OnStartCombat);
        }

        private static CombatEncounterService _combatEncounterService;

        private ICombatEncounter _currentCombat;

        /// <summary>
        /// Creates an instance of the combat encounter service.
        /// </summary>
        public static void Create()
        {
            _combatEncounterService = new CombatEncounterService();
        }

        /// <summary>
        /// Called when [start combat].
        /// </summary>
        /// <param name="m">The m.</param>
        private void OnStartCombat(StartCombatMessage m)
        {
            EventAggregator.Publish(new CombatStartedEvent(m.Players, m.Monsters));

            _currentCombat = new CombatEncounter()
                .SetPlayers(m.Players)
                .AddMonsters(m.Monsters)
                .BeginCombat();            
        }
    }
}