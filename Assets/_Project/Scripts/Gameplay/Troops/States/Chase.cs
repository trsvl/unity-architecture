using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Chase : TroopStateNode
    {
        private new readonly AttackingTroop _troop;
        private Vector2 _troopVelocityRandomValue;


        public Chase(IAnimationListener animationListener, AttackingTroop troop) : base(animationListener, troop)
        {
            _troop = troop;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _troopVelocityRandomValue = new Vector2(Random.Range(-1.0f, .5f), Random.Range(-1.0f, 0.5f));
        }

        public override void FixedUpdate()
        {
            if (!_troop.ClosestTarget) return;

            Vector2 direction = (_troop.ClosestDamageableTarget.Collider.ClosestPoint(_troop.Rb.position) - _troop.Rb.position).normalized;
            _troop.Rb.velocity = (direction * _troop.Config.MoveSpeed) + _troopVelocityRandomValue;
        }

        public override void OnExit()
        {
            base.OnExit();
            _troop.Rb.velocity = new Vector2(0, 0);
        }
    }
}