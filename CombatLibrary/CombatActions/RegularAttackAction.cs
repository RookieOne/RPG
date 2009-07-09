namespace CombatLibrary.CombatActions
{
    public class RegularAttackAction : CombatAction
    {
        public RegularAttackAction(int attackPower)
        {
            _attackPower = attackPower;
        }

        private readonly int _attackPower;

        protected override void OnExecute()
        {
            _target.TakeDamage(_attackPower);
        }
    }
}