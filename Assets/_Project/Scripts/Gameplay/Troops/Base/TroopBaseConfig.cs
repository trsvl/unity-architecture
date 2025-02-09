using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops.Base
{
    [CreateAssetMenu(fileName = "TroopBaseConfig", menuName = "SO/Troop/TroopBaseConfig", order = 0)]
    public class TroopBaseConfig : BaseConfig
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float SpawnCooldown { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float DamageScale { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public float AttackCooldown { get; private set; }
        [field: SerializeField] public ulong Price { get; set; }
        [field: SerializeField] public float PriceScale { get; set; }

        private void AssignDefaultVariables(TroopBase troop, StateMachine stateMachine)
        {
            var rb = troop.GetComponent<Rigidbody2D>();
            var collider = troop.GetComponent<Collider2D>();
            var spriteRenderer = troop.GetComponent<SpriteRenderer>();

            troop.AssignDefaultVariables(rb, collider, spriteRenderer, stateMachine);
        }

        public override PoolBase OnCreate()
        {
            var obj = Instantiate(Prefab);
            var troop = obj.GetComponent<TroopBase>();

            var animator = troop.GetComponent<Animator>();
            var animationListener = new TroopBaseAnimationListener(animator);

            var detectionTargets = troop.GetComponentInChildren<DetectionTargets>();
            detectionTargets.Init(troop);

            var attackTimer = new StopWatchTimer(AttackCooldown);
            var stateMachine = new TroopBaseStateMachine(troop, animationListener, attackTimer).GetStateMachine();

            troop.Config = this;
            troop.AttackTimer = attackTimer;
            troop.AnimationListener = animationListener;

            AssignDefaultVariables(troop, stateMachine);

            obj.SetActive(false);
            return troop;
        }

        public override void OnSpawn(TroopBase troop, Team team, int level)
        {
            troop.Spawn(team, level);
        }
    }
}