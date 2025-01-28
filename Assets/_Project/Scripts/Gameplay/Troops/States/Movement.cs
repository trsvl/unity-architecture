using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Movement : BaseMachineState
    {
        private readonly ITroopBase _iTroop;
        private readonly DetectionTargets _detectionTargets;


        public Movement(ITroopBase iTroop, DetectionTargets detectionTargets)
        {
            _iTroop = iTroop;
            _detectionTargets = detectionTargets;
        }

        public override void OnEnter()
        {
            Debug.Log("enter movement");
            base.OnEnter();
            _detectionTargets.Enable();
        }

        public override void FixedUpdate()
        {
            if (IsEnter)
            {
                _iTroop.Rb.velocity = new Vector2(_iTroop.Team == Team.Player ? 1 : -1, 0) * _iTroop.Config.MoveSpeed;
                IsEnter = false;
            }

            if (IsExit)
            {
                Debug.Log("exit movement");
                _iTroop.Rb.velocity = new Vector2(0, 0);
                _detectionTargets.Disable();
                IsExit = false;
                IsNextState = true;
            }
        }
    }
}