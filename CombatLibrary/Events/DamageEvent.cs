using CombatLibrary.CombatMembers;

namespace CombatLibrary.Events
{
    /// <summary>
    /// Damage Event
    /// </summary>
    public class DamageEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DamageEvent"/> class.
        /// </summary>
        /// <param name="combatMember">The combat member.</param>
        /// <param name="damage">The damage.</param>
        public DamageEvent(ICombatMember combatMember, int damage)
        {
            CombatMember = combatMember;
            Damage = damage;
        }

        /// <summary>
        /// Gets or sets the combat member.
        /// </summary>
        /// <value>The combat member.</value>
        public ICombatMember CombatMember { get; private set; }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public int Damage { get; private set; }
    }
}