using CombatLibrary.CombatActions;
using CombatLibrary.CombatMembers;

namespace CombatLibrary.Messages
{
    public class PlayerActionMessage
    {
        public PlayerActionMessage(IPlayerCombatMember player,
                                   ICombatAction action)
        {
            Player = player;
            Action = action;
        }

        public ICombatAction Action { get; set; }
        public IPlayerCombatMember Player { get; set; }
    }
}