using System.Collections.Generic;
using System.Linq;
using CombatLibrary.CombatActions;
using CombatLibrary.CombatMembers;
using CombatLibrary.Events;
using CombatLibrary.Messages;
using Foundation.Eventing;
using Foundation.Messaging;

namespace CombatLibrary.CombatEncounters
{
    /// <summary>
    /// Implements ICombat Encounter
    /// </summary>
    public class CombatEncounter : ICombatEncounter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombatEncounter"/> class.
        /// </summary>
        public CombatEncounter()
        {
            _round = 0;
            _monsters = new List<IMonsterCombatMember>();

            MessageBroker.Register<PlayerActionMessage>(OnPlayerAction);
        }

        public List<IMonsterCombatMember> _monsters;
        public List<PlayerActionMessage> _playerActions;
        public IEnumerable<IPlayerCombatMember> _players;

        /// <summary>
        /// Adds the monsters to combat encounter.
        /// </summary>
        /// <param name="monsters">The monsters.</param>
        /// <returns></returns>
        public ICombatEncounter AddMonsters(IEnumerable<IMonsterCombatMember> monsters)
        {
            _monsters.AddRange(monsters);
            return this;
        }

        /// <summary>
        /// All the monsters are dead.
        /// </summary>
        /// <returns></returns>
        public bool AllMonstersAreDead()
        {
            foreach (var monster in _monsters)
                if (!monster.IsDead)
                {
                    return false;
                }
            return true;
        }

        /// <summary>
        /// All the players are dead.
        /// </summary>
        /// <returns></returns>
        public bool AllPlayersAreDead()
        {
            foreach (var player in _players)
                if (!player.IsDead)
                {
                    return false;
                }

            return true;
        }

        /// <summary>
        /// Asks for player actions.
        /// </summary>
        public void AskForPlayerActions()
        {
            foreach (var player in _players)
            {
                EventAggregator.Publish(new PlayerReadyForActionEvent(player));
            }
        }

        private int _round;

        /// <summary>
        /// Executes a combat round.
        /// </summary>
        public void ExecuteRound()
        {
            _round++;
            EventAggregator.Publish(new RoundBeganEvent(_round));

            var actions = new List<ICombatAction>();
            _playerActions.ForEach(m => actions.Add(m.Action));

            _monsters.ForEach(m => actions.Add(m.GetCombatAction(_players.Cast<ICombatMember>())));

            foreach (var action in actions)
            {
                action.Execute();

                if (AllPlayersAreDead())
                {
                    EventAggregator.Publish(new MonstersWinEvent());
                    return;
                }

                if (AllMonstersAreDead())
                {
                    EventAggregator.Publish(new PlayersWinEvent());
                    return;
                }
            }

            EventAggregator.Publish(new RoundEndEvent(_round));

            AskForPlayerActions();
        }

        /// <summary>
        /// Initializes the player actions.
        /// </summary>
        private void InitializePlayerActions()
        {
            _playerActions = new List<PlayerActionMessage>();
        }

        /// <summary>
        /// Called when [player action].
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnPlayerAction(PlayerActionMessage m)
        {
            PlayerActionMessage foundAction = _playerActions.FirstOrDefault(a => a.Player == m.Player);

            if (foundAction != null)
            {
                _playerActions.Remove(foundAction);
            }

            _playerActions.Add(m);

            bool allPlayersHaveAnAction = true;
            foreach (var player in _players)
            {
                if (!_playerActions.Exists(a => a.Player == player))
                {
                    allPlayersHaveAnAction = false;
                    break;
                }
            }

            if (allPlayersHaveAnAction)
                ExecuteRound();
        }

        /// <summary>
        /// Sets the players.
        /// </summary>
        /// <param name="players">The players.</param>
        /// <returns></returns>
        public ICombatEncounter SetPlayers(IEnumerable<IPlayerCombatMember> players)
        {
            InitializePlayerActions();

            _players = players;

            AskForPlayerActions();

            return this;
        }
    }
}