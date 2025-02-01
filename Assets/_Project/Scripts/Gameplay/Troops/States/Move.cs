using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Move : TroopStateNode
    {
        private int _movingDirection;

        public Move(IAnimationListener animationListener, TroopBase troop) : base(
            animationListener, troop)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _movingDirection = _troop.Team == Team.Player ? 1 : -1;
        }

        public override void FixedUpdate()
        {
            if (IsEnter)
            {
                _troop.Rb.velocity = new Vector2(_movingDirection, 0) * _troop.Config.MoveSpeed;
                IsEnter = false;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            _troop.Rb.velocity = new Vector2(0, 0);
        }
    }
}