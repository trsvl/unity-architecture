using _Project.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class TroopBase : PoolBase, ITroop, IDamageable
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
        protected StateMachine _stateMachine;


        public virtual void Create(Rigidbody2D rb)
        {
            print("Creating TroopBase");
            Rb = rb;
            print("RB " + rb.gameObject.name);
            _stateMachine = new StateMachine();
            var movement = Movement(this, GetComponent<DetectionTargets>());
            _stateMachine.AddTransition(movement);
            _stateMachine.CurrentState = movement.State;
        }

        private StateNode Movement(TroopBase troop, DetectionTargets detectionTargets)
        {
            var move = new Movement(troop, detectionTargets);

            StateNode stateNode = new StateNode(move, Condition);
            return stateNode;

            bool Condition()
            {
                return !troop.closestTarget;
            }
        }

        public void Spawn(Team team)
        {
            Team = team;
            gameObject.tag = team.ToString();
            OpponentTag = (Team == Team.Player ? Team.Enemy : Team.Player).ToString();
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