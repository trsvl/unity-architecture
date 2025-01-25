using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class TroopTest : MonoBehaviour, IDamageable
    {
        public Team Team { get; private set; }
        public string TargetTag { get; private set; }
        public float attackRange = 2f;

        [SerializeField] private float health = 10f;

        private StateMachine _stateMachine;

        public Rigidbody2D Rb { get; private set; }

        public IDamageable ClosestDamageableTarget
        {
            get
            {
                if (ClosestTargetCollider && closestDamageableTarget != null)
                {
                    return closestDamageableTarget;
                }

                return null;
            }
            set => closestDamageableTarget = value;
        }

        private IDamageable closestDamageableTarget = null;

        public Collider2D ClosestTargetCollider
        {
            get
            {
                if (closestTargetCollider && closestTargetCollider.gameObject.activeSelf)
                {
                    return closestTargetCollider;
                }

                return null;
            }
            set => closestTargetCollider = value;
        }

        private Collider2D closestTargetCollider = null;


        public void Init(StateMachine stateMachine)
        {
           // _stateMachine = stateMachine;
            Rb = GetComponent<Rigidbody2D>();
        }

        public void Spawn(Team team)
        {
            Team = team;
            var targetTeam = Team == Team.Player ? Team.Enemy : Team.Player;
            TargetTag = targetTeam.ToString();
            ClosestDamageableTarget = null;
            closestTargetCollider = null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }

        // private void Update()
        // {
        //     _stateMachine.Update();
        // }
        //
        // private void FixedUpdate()
        // {
        //     _stateMachine.currentState?.FixedUpdate();
        // }

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