namespace CombatLibrary.Events
{
    /// <summary>
    /// Round End Event
    /// </summary>
    public class RoundEndEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoundEndEvent"/> class.
        /// </summary>
        /// <param name="round">The round.</param>
        public RoundEndEvent(int round)
        {
            Round = round;
        }

        public int Round { get; set; }
    }
}