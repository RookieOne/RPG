using CombatLibrary.CombatMembers;
using CombatLibrary.Events;
using Foundation.Eventing;
using WpfFoundation.ViewModels;

namespace WpfCombat.PlayerPartyStatsView
{
    /// <summary>
    /// Player Combat Member View Model
    /// </summary>
    public class PlayerCombatMemberViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCombatMemberViewModel"/> class.
        /// </summary>
        /// <param name="playerCombatMember">The player combat member.</param>
        public PlayerCombatMemberViewModel(PlayerCombatMember playerCombatMember)
        {
            _playerCombatMember = playerCombatMember;
            Name = playerCombatMember.Name;
            CurrentHealth = TotalHealth = playerCombatMember.Health;

            EventAggregator.Subscribe<DamageEvent>(OnDamage);
        }

        private readonly PlayerCombatMember _playerCombatMember;
        private int _currentHealth;
        private string _name;
        private int _totalHealth;

        /// <summary>
        /// Gets or sets the current health.
        /// </summary>
        /// <value>The current health.</value>
        public int CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                _currentHealth = value;
                OnPropertyChanged("CurrentHealth");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the total health.
        /// </summary>
        /// <value>The total health.</value>
        public int TotalHealth
        {
            get { return _totalHealth; }
            set
            {
                _totalHealth = value;
                OnPropertyChanged("TotalHealth");
            }
        }

        /// <summary>
        /// Called when [damage].
        /// </summary>
        /// <param name="e">The e.</param>
        private void OnDamage(DamageEvent e)
        {
            if (e.CombatMember.Id != _playerCombatMember.Id)
                return;

            CurrentHealth -= e.Damage;
        }
    }
}