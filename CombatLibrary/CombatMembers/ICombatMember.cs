using System;

namespace CombatLibrary.CombatMembers
{
    public interface ICombatMember
    {
        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <value>The health.</value>
        int Health { get; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        Guid Id { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is dead.
        /// </summary>
        /// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
        bool IsDead { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>
        /// Adds the health.
        /// </summary>
        /// <param name="health">The health.</param>
        void AddHealth(int health);

        /// <summary>
        /// Takes damage.
        /// </summary>
        /// <param name="damage">The damage.</param>
        void TakeDamage(int damage);
    }
}