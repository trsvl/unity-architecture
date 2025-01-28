using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Chase : BaseMachineState
    {
        private readonly ITroopBase _troop;


        public Chase(ITroopBase troop)
        {
            _troop = troop;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Chasing troop");
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

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("exit chase");
        }
    }
}