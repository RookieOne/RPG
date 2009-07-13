namespace CombatLibrary.Events
{
    /// <summary>
    /// Round Began Event
    /// </summary>
    public class RoundBeganEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoundBeganEvent"/> class.
        /// </summary>
        /// <param name="round">The round.</param>
        public RoundBeganEvent(int round)
        {
            Round = round;
        }

        public int Round { get; set; }
    }
}