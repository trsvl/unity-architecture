using _Project.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class TroopBase : MonoBehaviour, ITroop, IDamageable
    {
        public Team Team { get; private set; }
        public string OpponentTag { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        public TroopBaseSO Config { get; private set; }

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

        private Transform closestTarget = null;
        private StateMachine _stateMachine;
        private float health;

        public void Init(TroopBaseSO config, StateMachine stateMachine)
        {
            Rb = GetComponent<Rigidbody2D>();
            Config = config;
            _stateMachine = stateMachine;
        }

        public void Spawn(Team team)
        {
            Team = team;
            gameObject.tag = team.ToString();
            OpponentTag = (Team == Team.Player ? Team.Enemy : Team.Player).ToString();
            closestTarget = null;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.currentState?.FixedUpdate();
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