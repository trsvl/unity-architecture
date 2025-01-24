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

        public override void FixedUpdate()
        {
            Vector2 direction = _troop.closestTargetCollider.transform.position - _troop.transform.position;
            _troop.rb.velocity = direction;
        }

        public override void OnExit()
        {
            _troop.rb.velocity = new Vector2(0, 0);
        }
    }
}