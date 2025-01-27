using _Project.Scripts.Gameplay.Troops;
using UnityEngine;

namespace _Project.Scripts.Gameplay.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AttackingTroop", menuName = "SO/Troops/AttackingTroop", order = 0)]
    public class AttackingTroopConfig : TroopBaseConfig
    {
        [field: SerializeField] public float AttackDamage { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }


        public override PoolBase OnCreate()
        {
            var obj = Instantiate(Prefab);
            var troop = obj.GetComponent<AttackingTroop>();

            var rb = troop.GetComponent<Rigidbody2D>();
            var detectionTargets = troop.GetComponent<DetectionTargets>();

            troop.Config = this;
            //var stateMachine = new StateMachine();

            //var movement = Movement(troop, detectionTargets);
            //var chase = Chase(troop);
            //var attack = Attack(troop);
            //stateMachine.AddTransition(movement);
            //stateMachine.AddTransition(chase);
            //stateMachine.AddTransition(attack);

            //stateMachine.CurrentState = movement.State;

            troop.Create(rb);
            obj.SetActive(false);
            return troop;
        }

        public override void OnSpawn(PoolBase obj, Team team)
        {
            if (obj is AttackingTroop troop)
            {
                troop.Spawn(team);
                troop.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("PoolBase must be AttackingTroop");
            }
        }

        // private StateNode Chase(AttackingTroop troop)
        // {
        //     var chase = new Chase(troop);
        //
        //     StateNode stateNode = new StateNode(chase, Condition);
        //     return stateNode;
        //
        //     bool Condition()
        //     {
        //         if (!troop.ClosestTarget) return false;
        //
        //
        //         Vector2 directionToTarget =
        //             troop.ClosestTarget.transform.position - troop.transform.position;
        //         float distanceToTarget = directionToTarget.magnitude;
        //         Debug.Log("attack range" + troop.Config.AttackRange);
        //         Debug.Log("magnitude distance: " + distanceToTarget);
        //         Debug.Log("vector distance: " +
        //                   Vector2.Distance(troop.transform.position, troop.ClosestTarget.transform.position));
        //
        //         return troop.ClosestTarget && distanceToTarget > troop.Config.AttackRange;
        //     }
        // }

        private StateNode Movement(AttackingTroop troop, DetectionTargets detectionTargets)
        {
            var move = new Movement(troop, detectionTargets);

            StateNode stateNode = new StateNode(move, Condition);
            return stateNode;

            bool Condition()
            {
                return !troop.ClosestTarget;
            }
        }

        // private StateNode Attack(AttackingTroop troop)
        // {
        //     var attack = new Attack(troop);
        //
        //     StateNode stateNode = new StateNode(attack, Condition);
        //     return stateNode;
        //
        //     bool Condition()
        //     {
        //         if (!troop.ClosestTarget) return false;
        //
        //         Vector2 directionToTarget =
        //             troop.ClosestTarget.transform.position - troop.transform.position;
        //         float distanceToTarget = directionToTarget.magnitude;
        //         return troop.ClosestTarget && distanceToTarget < troop.Config.AttackRange;
        //     }
        // }
    }
}