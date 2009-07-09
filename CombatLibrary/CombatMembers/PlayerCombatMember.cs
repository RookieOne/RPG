namespace CombatLibrary.CombatMembers
{
    public class PlayerCombatMember : CombatMember
    {
        public PlayerCombatMember(int health)
        {
            AddHealth(health);
        }
    }
}