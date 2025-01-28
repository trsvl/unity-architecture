using _Project.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class ITroopBase : PoolBase, ITroop, IDamageable
    {
        public Team Team { get; private set; }
        public string OpponentTag { get; private set; }
        public Rigidbody2D Rb { get; private set; }

        public new TroopBaseConfig Config
        {
            get => (TroopBaseConfig)base.Config;
            set => base.Config = value;
        }

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

        private Transform closestTarget;
        private float health;
        private StateMachine _stateMachine;


        public virtual void Create(Rigidbody2D rb, StateMachine stateMachine)
        {
            Rb = GetComponent<Rigidbody2D>();
            _stateMachine = stateMachine;
        }

        public void Spawn(Team team)
        {
            Team = team;
            gameObject.tag = team.ToString();
            OpponentTag = (Team == Team.Player ? Team.Enemy : Team.Player).ToString();
            gameObject.transform.rotation = Quaternion.Euler(0f, Team == Team.Player ? 0f : 180f, 0f);
            closestTarget = null;
            health = Config.MaxHealth;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState?.FixedUpdate();
        }

        public void TakeDamage(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                //return to pool
            }
        }
    }
}