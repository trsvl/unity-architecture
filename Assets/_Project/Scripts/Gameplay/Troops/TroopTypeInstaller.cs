using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class TroopTypeInstaller : MonoBehaviour
    {
        [SerializeField] private Troop troopPrefab;

        private float health;
        private Troop troop;

        private Chase chase;

        public void Init()
        {
            troop = Instantiate(troopPrefab);
            var detectionTargets = GetComponent<DetectionTargets>();

            var stateMachine = new StateMachine();
            stateMachine.AddTransition(Chase());


            troop.Init(stateMachine);
        }

        private StateNode Chase()
        {
            chase = new Chase(troop);

            StateNode stateNode = new StateNode(chase, Condition);
            return stateNode;

            bool Condition()
            {
                return troop.closestTargetCollider;
            }
        }
    }
}