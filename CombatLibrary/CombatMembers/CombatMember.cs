using CombatLibrary.Events;
using Foundation.Eventing;

namespace CombatLibrary.CombatMembers
{
    public abstract class CombatMember : ICombatMember
    {
        public int Health { get; private set; }

        public bool IsDead
        {
            get { return Health <= 0; }
        }

        public void AddHealth(int health)
        {
            Health += health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
            {
                Health = 0;
                EventAggregator.Publish(new CombatDeathEvent(this));
            }
        }
    }
}