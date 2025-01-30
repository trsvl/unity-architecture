using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Move : TroopStateNode
    {
        private readonly TroopBase _troop;


        public Move(IAnimationListener animationListener, TroopBase troop) : base(
            animationListener)
        {
            _troop = troop;
        }

        public override void FixedUpdate()
        {
            if (IsEnter)
            {
                _troop.Rb.velocity = new Vector2(_troop.Team == Team.Player ? 1 : -1, 0) * _troop.Config.MoveSpeed;
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