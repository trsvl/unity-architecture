using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Chase : TroopStateNode
    {
        private readonly TroopBase _troop;


        public Chase(IAnimationListener animationListener, TroopBase troop) : base(animationListener)
        {
            _troop = troop;
        }

        public override void FixedUpdate()
        {
            Vector2 direction = _troop.ClosestTarget.position - _troop.transform.position;
            _troop.Rb.velocity = direction.normalized * _troop.Config.MoveSpeed;
        }

        public override void OnExit()
        {
            base.OnExit();
            _troop.Rb.velocity = new Vector2(0, 0);
        }
    }
}