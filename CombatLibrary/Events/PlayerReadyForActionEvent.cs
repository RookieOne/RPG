using CombatLibrary.CombatMembers;

namespace CombatLibrary.Events
{
    /// <summary>
    /// Player Ready For Action Event
    /// </summary>
    public class PlayerReadyForActionEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerReadyForActionEvent"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public PlayerReadyForActionEvent(IPlayerCombatMember player)
        {
            Player = player;
        }

        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>The player.</value>
        public IPlayerCombatMember Player { get; private set; }
    }
}