using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Movement : BaseMachineState
    {
        private readonly Troop _troop;
        private readonly float _moveSpeed;


        public Movement(Troop troop, float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }

        public override void OnEnter()
        {
            _troop.rb.velocity = new Vector2(_troop.Team == Team.Player ? 1 : -1, 0) * _moveSpeed;
        }

        public override void OnExit()
        {
            _troop.rb.velocity = new Vector2(0, 0);
        }
    }
}