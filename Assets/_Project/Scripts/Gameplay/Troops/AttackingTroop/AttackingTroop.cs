using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class AttackingTroop : TroopBase, IAttack
    {
        public new AttackingTroopConfig Config
        {
            get { return (AttackingTroopConfig)base.Config; }
            set { base.Config = value; }
        }

        public IDamageable ClosestDamageableTarget
        {
            get
            {
                if (ClosestTarget && closestDamageableTarget != null)
                {
                    return closestDamageableTarget;
                }

                return null;
            }
            set => closestDamageableTarget = value;
        }

        public StopWatchTimer AttackTimer { get; private set; }
        public new IAttackAnimationListener AnimationListener { get;  set; }

        private IDamageable closestDamageableTarget = null;


        public void Create(Rigidbody2D rb, StateMachine stateMachine,
            StopWatchTimer attackTimer)
        {
            base.Create(rb, stateMachine);
            AttackTimer = attackTimer;
        }


        protected override void Update()
        {
            AttackTimer.Update(Time.deltaTime);
            base.Update();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Config.AttackRange);
        }
    }
}