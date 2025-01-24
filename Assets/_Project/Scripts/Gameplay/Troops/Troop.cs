using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Troop : MonoBehaviour, IDamageable
    {
        public Team Team { get; private set; }
        public string targetTag { get; private set; }

        [SerializeField] private float health = 10f;

        private StateMachine _stateMachine;

        public Rigidbody2D rb { get; private set; }
        public IDamageable closestDamageableTarget { get; set; } = null;
        public Collider2D closestTargetCollider { get; set; } = null;


        public void Init(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            rb = GetComponent<Rigidbody2D>();
        }

        public void Spawn(Team team)
        {
            Team = team;
            var targetTeam = Team == Team.Player ? Team.Enemy : Team.Player;
            targetTag = targetTeam.ToString();
            closestDamageableTarget = null;
            closestTargetCollider = null;
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