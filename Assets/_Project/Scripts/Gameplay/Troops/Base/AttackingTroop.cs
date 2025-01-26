using _Project.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class AttackingTroop : TroopBase, IAttack
    {
        public new AttackingTroopSO Config => base.Config as AttackingTroopSO;

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

        private IDamageable closestDamageableTarget = null;
        private StateMachine _stateMachine;
        private float health;


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Config.AttackRange);
        }
    }
}