using _Project.Scripts.Gameplay._troops;
using _Project.Scripts.Gameplay.Troops;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
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
            troop.Config = this;
            var rb = troop.gameObject.GetComponent<Rigidbody2D>();
            var animator = troop.gameObject.GetComponent<Animator>();
            var detectionTargets = troop.GetComponentInChildren<DetectionTargets>();
            detectionTargets.Init(troop);

            var stateMachine = new AttackingTroopStateMachine(troop, animator, detectionTargets).GetStateMachine();

            troop.Create(rb, stateMachine);
            obj.SetActive(false);
            return troop;
        }

        public override void OnSpawn(PoolBase obj, Team team)
        {
            if (obj is AttackingTroop troop)
            {
                troop.Spawn(team);
            }
            else
            {
                Debug.LogError("PoolBase must be AttackingTroop");
            }
        }
    }
}