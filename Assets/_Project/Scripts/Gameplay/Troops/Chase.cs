using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Chase : BaseMachineState
    {
        private readonly Troop _troop;


        public Chase(Troop troop)
        {
            _troop = troop;
        }

        public override void OnEnter()
        {
            Debug.Log("Chasing troop");
        }

        public override void FixedUpdate()
        {
            Vector2 direction = _troop.ClosestTargetCollider.transform.localPosition - _troop.transform.localPosition;
            _troop.Rb.velocity = direction.normalized * _troop.moveSpeed;
        }

        public override void OnExit()
        {
            Debug.Log("exit chase");
            _troop.Rb.velocity = new Vector2(0, 0);
        }
    }
}