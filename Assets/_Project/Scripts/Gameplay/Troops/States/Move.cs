using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Move : TroopState
    {
        private readonly TroopBase _troop;
        private readonly DetectionTargets _detectionTargets;


        public Move(IAnimationListener animationListener, TroopBase troop, DetectionTargets detectionTargets) : base(
            animationListener)
        {
            _troop = troop;
            _detectionTargets = detectionTargets;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _detectionTargets.Enable();
        }

        public override void FixedUpdate()
        {
            if (IsEnter)
            {
                _troop.Rb.velocity = new Vector2(_troop.Team == Team.Player ? 1 : -1, 0) * _troop.Config.MoveSpeed;
                IsEnter = false;
            }

            if (IsExit)
            {
                _troop.Rb.velocity = new Vector2(0, 0);
                _detectionTargets.Disable();
                IsExit = false;
                IsNextState = true;
            }
        }
    }
}