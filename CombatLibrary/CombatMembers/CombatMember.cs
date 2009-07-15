using CombatLibrary.Events;
using Foundation.Eventing;

namespace CombatLibrary.CombatMembers
{
    /// <summary>
    /// Combat Member
    /// </summary>
    public abstract class CombatMember : ICombatMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombatMember"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected CombatMember(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>The health.</value>
        public int Health { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is dead.
        /// </summary>
        /// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
        public bool IsDead
        {
            get { return Health <= 0; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Adds the health.
        /// </summary>
        /// <param name="health">The health.</param>
        public void AddHealth(int health)
        {
            Health += health;
        }

        /// <summary>
        /// Takes the damage.
        /// </summary>
        /// <param name="damage">The damage.</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;

            EventAggregator.Publish(new DamageEvent(this, damage));

            if (Health < 0)
            {
                Health = 0;
                EventAggregator.Publish(new CombatDeathEvent(this));
            }
        }
    }
}