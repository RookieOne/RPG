namespace CombatLibrary.CombatActions
{
    /// <summary>
    /// Regular Attack Action
    /// </summary>
    public class RegularAttackAction : CombatAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegularAttackAction"/> class.
        /// </summary>
        /// <param name="attackPower">The attack power.</param>
        public RegularAttackAction(int attackPower)
        {
            AttackPower = attackPower;
        }

        /// <summary>
        /// Gets or sets the attack power.
        /// </summary>
        /// <value>The attack power.</value>
        public int AttackPower { get; private set; }

        /// <summary>
        /// Called when [execute].
        /// </summary>
        protected override void OnExecute()
        {
            _target.TakeDamage(AttackPower);
        }
    }
}