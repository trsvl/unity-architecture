using _Project.Scripts.Gameplay._troops;
using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    [CreateAssetMenu(fileName = "AttackingTroop", menuName = "SO/Troops/AttackingTroop", order = 0)]
    public class AttackingTroopConfig : TroopBaseConfig
    {
        [field: SerializeField] public float AttackDamage { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public float AttackCooldown { get; private set; }


        public override PoolBase OnCreate()
        {
            var obj = Instantiate(Prefab);

            var troop = obj.GetComponent<AttackingTroop>();
            troop.Config = this;
            var rb = troop.gameObject.GetComponent<Rigidbody2D>();
            var spriteRenderer = troop.gameObject.GetComponent<SpriteRenderer>();
            
            var animator = troop.gameObject.GetComponent<Animator>();
            var animationListener = troop.gameObject.GetComponent<AttackingTroopAnimationListener>();
            animationListener.Init(animator);
            troop.AnimationListener = animationListener;

            var detectionTargets = troop.GetComponentInChildren<DetectionTargets>();
            detectionTargets.Init(troop);

            var attackTimer = new StopWatchTimer(AttackCooldown);
            var stateMachine = new AttackingTroopStateMachine(troop, animationListener, attackTimer).GetStateMachine();

            troop.Create(rb,spriteRenderer, stateMachine, attackTimer);
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