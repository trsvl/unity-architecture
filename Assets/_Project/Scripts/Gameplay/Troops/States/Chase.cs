using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Chase : TroopStateNode
    {
        private readonly TroopBase _troop;
        private Vector2 _troopVelocityRandomValue;


        public Chase(IAnimationListener animationListener, TroopBase troop) : base(animationListener)
        {
            _troop = troop;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _troopVelocityRandomValue = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        }

        public override void FixedUpdate()
        {
            if (!_troop.ClosestTarget) return;

            Vector2 direction = _troop.ClosestTarget.position - _troop.transform.position;
            _troop.Rb.velocity = (direction.normalized * _troop.Config.MoveSpeed) + _troopVelocityRandomValue;
        }

        public override void OnExit()
        {
            base.OnExit();
            _troop.Rb.velocity = new Vector2(0, 0);
        }
    }
}