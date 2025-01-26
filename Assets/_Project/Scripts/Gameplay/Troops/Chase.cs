using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Chase : BaseMachineState
    {
        private readonly TroopBase _troop;


        public Chase(TroopBase troop)
        {
            _troop = troop;
        }

        public override void OnEnter()
        {
            Debug.Log("Chasing troop");
        }

        public override void FixedUpdate()
        {
            Vector2 direction = _troop.ClosestTarget.localPosition - _troop.transform.localPosition;
            _troop.Rb.velocity = direction.normalized * _troop.Config.MoveSpeed;
        }

        public override void OnExit()
        {
            Debug.Log("exit chase");
            _troop.Rb.velocity = new Vector2(0, 0);
        }
    }
}