using _Project.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class AttackingTroopInstaller : MonoBehaviour
    {
        [SerializeField] private AttackingTroopSO _troopConfig;

        private AttackingTroop _troop;
        private DetectionTargets detectionTargets;


        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _troop = Instantiate(_troopConfig.TroopPrefab);
            detectionTargets = GetComponent<DetectionTargets>();

            var stateMachine = new StateMachine();

            stateMachine.AddTransition(Movement());
            stateMachine.AddTransition(Chase());
            stateMachine.AddTransition(Attack());

            stateMachine.currentState = Movement().State;

            _troop.Init(_troopConfig, stateMachine);
        }

        private StateNode Chase()
        {
            var chase = new Chase(_troop);

            StateNode stateNode = new StateNode(chase, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTarget) return false;


                Vector2 directionToTarget =
                    _troop.ClosestTarget.transform.position - transform.position;
                float distanceToTarget = directionToTarget.magnitude;
                Debug.Log("attack range" + _troop.Config.AttackRange);
                Debug.Log("magnitude distance: " + distanceToTarget);
                Debug.Log("vector distance: " +
                          Vector2.Distance(transform.position, _troop.ClosestTarget.transform.position));

                return _troop.ClosestTarget && distanceToTarget > _troop.Config.AttackRange;
            }
        }

        private StateNode Movement()
        {
            var move = new Movement(_troop, detectionTargets);

            StateNode stateNode = new StateNode(move, Condition);
            return stateNode;

            bool Condition()
            {
                return !_troop.ClosestTarget;
            }
        }

        private StateNode Attack()
        {
            var attack = new Attack(_troop);

            StateNode stateNode = new StateNode(attack, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTarget) return false;

                Vector2 directionToTarget =
                    _troop.ClosestTarget.transform.position - transform.position;
                float distanceToTarget = directionToTarget.magnitude;
                return _troop.ClosestTarget && distanceToTarget < _troop.Config.AttackRange;
            }
        }
    }
}