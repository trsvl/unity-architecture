using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Chase : TroopState
    {
        private readonly TroopBase _troop;


        public Chase(IAnimationListener animationListener, TroopBase troop) : base(animationListener)
        {
            _troop = troop;
        }

        public override void FixedUpdate()
        {
            if (IsEnter)
            {
                Vector2 direction = _troop.ClosestTarget.position - _troop.transform.position;
                _troop.Rb.velocity = direction.normalized * _troop.Config.MoveSpeed;
            }

            if (IsExit)
            {
                _troop.Rb.velocity = new Vector2(0, 0);
                IsNextState = true;
                IsExit = false;
            }
        }
    }
}