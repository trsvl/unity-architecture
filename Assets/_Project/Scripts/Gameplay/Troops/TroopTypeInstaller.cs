using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class TroopTypeInstaller : MonoBehaviour
    {
        [SerializeField] private Troop troopPrefab;

        private float health;
        private Troop _troop;

        private DetectionTargets detectionTargets;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _troop = Instantiate(troopPrefab);
            detectionTargets = GetComponent<DetectionTargets>();

            var stateMachine = new StateMachine();

            stateMachine.AddTransition(Movement());
            stateMachine.AddTransition(Chase());
            stateMachine.AddTransition(Attack());

            stateMachine.currentState = Movement().State;

            _troop.Init(stateMachine);
        }

        private StateNode Chase()
        {
            var chase = new Chase(_troop);

            StateNode stateNode = new StateNode(chase, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTargetCollider) return false;


                Vector2 directionToTarget =
                    _troop.ClosestTargetCollider.transform.position - transform.position;
                float distanceToTarget = directionToTarget.magnitude;
                Debug.Log("attack range" + _troop.attackRange);
                Debug.Log("magnitude distance: " + distanceToTarget);
                Debug.Log("vector distance: " +
                          Vector2.Distance(transform.position, _troop.ClosestTargetCollider.transform.position));

                return _troop.ClosestTargetCollider && distanceToTarget > _troop.attackRange;
            }
        }

        private StateNode Movement()
        {
            var move = new Movement(_troop, detectionTargets);

            StateNode stateNode = new StateNode(move, Condition);
            return stateNode;

            bool Condition()
            {
                return !_troop.ClosestTargetCollider;
            }
        }

        private StateNode Attack()
        {
            var attack = new Attack(_troop, 1f);

            StateNode stateNode = new StateNode(attack, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTargetCollider) return false;

                Vector2 directionToTarget =
                    _troop.ClosestTargetCollider.transform.position - transform.position;
                float distanceToTarget = directionToTarget.magnitude;
                return _troop.ClosestTargetCollider && distanceToTarget < _troop.attackRange;
            }
        }
    }
}