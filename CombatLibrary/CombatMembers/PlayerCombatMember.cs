namespace CombatLibrary.CombatMembers
{
    /// <summary>
    /// Player Combat Member
    /// </summary>
    public class PlayerCombatMember : CombatMember, IPlayerCombatMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCombatMember"/> class.
        /// </summary>
        /// <param name="health">The health.</param>
        /// <param name="name">The name.</param>
        public PlayerCombatMember(int health, string name)
            : base(name)
        {
            AddHealth(health);
        }
    }
}