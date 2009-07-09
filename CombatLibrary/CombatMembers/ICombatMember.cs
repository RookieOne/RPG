namespace CombatLibrary.CombatMembers
{
    public interface ICombatMember
    {
        int Health { get; }
        bool IsDead { get; }
        void AddHealth(int health);
        void TakeDamage(int damage);
    }
}