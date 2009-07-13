using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CombatLibrary.Events;
using Foundation.Eventing;

namespace RPGConsole
{
    class Program
    {
        public class TempCombatMember
        {
            public int Health { get; set; }
            public bool IsDead { get; set; }
            public TempCombatMember(int health)
            {
                Health = health;
                IsDead = false;
            }
        }

        static void Main(string[] args)
        {
            EventAggregator.Subscribe<PlayerReadyForActionEvent>(OnPlayerReadyForAction);


        }

        private static void OnPlayerReadyForAction(PlayerReadyForActionEvent e)
        {
            Console.WriteLine("Player Ready");
            var input = Console.ReadLine();


        }
    }
}
