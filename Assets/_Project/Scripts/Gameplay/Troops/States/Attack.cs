using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Attack : TroopStateNode
    {
        private readonly AttackingTroop _troop;
        private readonly StopWatchTimer _attackTimer;


        public Attack(IAnimationListener animationListener, AttackingTroop troop, StopWatchTimer attackTimer) : base(
            animationListener)
        {
            _troop = troop;
            _attackTimer = attackTimer;
        }

        public override void Update()
        {
            if (_attackTimer.IsReady)
            {
                Hit();
            }
        }

        private void Hit()
        {
            Debug.Log("Hit");
            _attackTimer.Reset();
            _troop.ClosestDamageableTarget.TakeDamage(_troop.Config.AttackDamage);
        }
    }
}