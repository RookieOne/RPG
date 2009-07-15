using System;
using System.Collections.Generic;
using CombatLibrary.CombatActions;
using CombatLibrary.CombatActionStrategies;
using CombatLibrary.CombatEncounters;
using CombatLibrary.CombatMembers;
using CombatLibrary.Events;
using CombatLibrary.Messages;
using CombatLibrary.TargetStrategies;
using Foundation.Eventing;
using Foundation.Messaging;

namespace RPGConsole
{
    internal class Program
    {
        private static List<IMonsterCombatMember> _monsters;
        private static List<IPlayerCombatMember> _party;

        private static void Main(string[] args)
        {
            MessageBroker.SetMessageBroker(new DefaultMessageBroker());
            EventAggregator.SetAggregator(new DefaultEventAggregator());

            CombatEncounterService.Create();

            EventAggregator
                .Subscribe<PlayerReadyForActionEvent>(OnPlayerReadyForAction)
                .Subscribe<DamageEvent>(OnDamage)
                .Subscribe<RoundBeganEvent>(OnRoundStart)
                .Subscribe<RoundEndEvent>(OnRoundEnd)
                .Subscribe<PlayersWinEvent>(OnPlayersWin)
                .Subscribe<MonstersWinEvent>(OnMonstersWin)
                .Subscribe<CombatStartedEvent>(OnCombatStarted);

            _party = new List<IPlayerCombatMember>();
            _party.Add(new PlayerCombatMember(100, "JB"));

            _monsters = new List<IMonsterCombatMember>();

            IMonsterCombatMember monster = new MonsterCombatMember(20, "Monster")
                .SetTargetStrategy(new RandomTargetStrategy())
                .SetCombatActionStrategy(new RegularAttackStrategy());
            _monsters.Add(monster);
                      
            var message = new StartCombatMessage(_party, _monsters);
            MessageBroker.Send(message);

            while (true)
            {
            }
        }

        private static void OnCombatStarted(CombatStartedEvent e)
        {
            PrintCombat();  
        }

        private static void OnDamage(DamageEvent e)
        {
            Console.WriteLine("{0} takes {1} damage", e.CombatMember.Name, e.Damage);
        }

        private static void OnMonstersWin(MonstersWinEvent e)
        {
            Console.WriteLine("Monsters Win!");
        }

        private static void OnPlayerReadyForAction(PlayerReadyForActionEvent e)
        {
            Console.WriteLine("Player Ready");
            string input = Console.ReadLine();

            int index = Convert.ToInt16(input);

            ICombatAction action = new RegularAttackAction(10).SetTarget(_monsters[index]);

            var message = new PlayerActionMessage(e.Player, action);
            MessageBroker.Send(message);
        }

        private static void OnPlayersWin(PlayersWinEvent e)
        {
            Console.WriteLine("Players Win!");
        }

        private static void OnRoundEnd(RoundEndEvent e)
        {
            Console.WriteLine("Round {0} Ended", e.Round);
            Console.WriteLine();

            PrintCombat();
        }

        private static void OnRoundStart(RoundBeganEvent e)
        {
            Console.WriteLine("Round {0} Started", e.Round);
        }

        private static void PrintCombat()
        {
            Console.WriteLine("Monsters");
            _monsters.ForEach(m => Console.WriteLine("{0} has {1} health", m.Name, m.Health));
            Console.WriteLine();

            Console.WriteLine("Players");
            _party.ForEach(p => Console.WriteLine("{0} has {1} health", p.Name, p.Health));
            Console.WriteLine();
        }
    }
}