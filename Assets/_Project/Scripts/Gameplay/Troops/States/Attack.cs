namespace _Project.Scripts.Gameplay.Troops
{
    public class Attack : TroopStateNode
    {
        private readonly AttackingTroop _troop;


        public Attack(IAnimationListener animationListener, AttackingTroop troop) : base(animationListener)
        {
            _troop = troop;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            //attack first time
        }

        public override void Update()
        {
            base.Update();
            //timer
            //Hit()
        }

        private void Hit()
        {
            _troop.ClosestDamageableTarget.TakeDamage(_troop.Config.AttackDamage);
        }
    }
}