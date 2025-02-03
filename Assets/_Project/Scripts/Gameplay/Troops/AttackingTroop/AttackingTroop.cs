using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class AttackingTroop : TroopBase, IAttack
    {
        public new AttackingTroopConfig Config
        {
            get => (AttackingTroopConfig)base.Config;
            set => base.Config = value;
        }

        public IDamageable ClosestDamageableTarget { get; set; }
        public StopWatchTimer AttackTimer { get;  set; }
        public new IAttackAnimationListener AnimationListener { get; set; }


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