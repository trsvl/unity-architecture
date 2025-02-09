using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops.Base
{
    public class TroopBase : PoolBase, ITroop, IDamageable, IAttack
    {
        public Transform ClosestTarget
        {
            get
            {
                if (closestTarget && closestTarget.gameObject.activeSelf)
                {
                    return closestTarget;
                }

                return null;
            }
            set => closestTarget = value;
        }

        public new TroopBaseConfig Config
        {
            get => (TroopBaseConfig)base.Config;
            set => base.Config = value;
        }

        public Team Team { get; private set; }
        public string OpponentTag { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        public Collider2D Collider { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }
        public int Level { get; set; }
        public StopWatchTimer AttackTimer { get; set; }
        public IDamageable ClosestDamageableTarget { get; set; }
        public IAnimationListener AnimationListener { get; set; }

        private Transform closestTarget;
        private float health;
        private StateMachine _stateMachine;


        public void AssignDefaultVariables(Rigidbody2D rb, Collider2D troopCollider, SpriteRenderer spriteRenderer,
            StateMachine stateMachine)
        {
            Rb = rb;
            Collider = troopCollider;
            SpriteRenderer = spriteRenderer;
            _stateMachine = stateMachine;
        }

        public void Spawn(Team team, int level)
        {
            Team = team;
            Level = level;
            gameObject.tag = team.ToString();
            OpponentTag = (Team == Team.Player ? Team.Enemy : Team.Player).ToString();
            closestTarget = null;
            health = Config.MaxHealth;
            CheckRotation();
        }

        protected virtual void Update()
        {
            AttackTimer.Update(Time.deltaTime);
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        public void TakeDamage(float damage)
        {
            if (health > 0)
            {
                TroopEvents.Instance.TakeDamage(this);
                health -= damage;
            }
            else
            {
                TroopEvents.Instance.Death(this);
            }
        }

        public void CheckRotation()
        {
            if (ClosestTarget && transform.position.x > ClosestTarget.position.x)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (ClosestTarget && transform.position.x < ClosestTarget.position.x)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, Team == Team.Player ? 0f : 180f, 0f);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Config.AttackRange);
        }
    }
}