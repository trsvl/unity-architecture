using _Project.Scripts.Gameplay.ScriptableObjects;
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

        private IDamageable closestDamageableTarget = null;
    }
}