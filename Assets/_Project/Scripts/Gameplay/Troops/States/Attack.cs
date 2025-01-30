using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Attack : TroopStateNode
    {
        private readonly AttackingTroop _troop;
        private readonly StopWatchTimer _attackTimer;
        private IAttackAnimationListener _animationListener;


        public Attack(IAttackAnimationListener animationListener, AttackingTroop troop, StopWatchTimer attackTimer) :
            base(animationListener)
        {
            _troop = troop;
            _attackTimer = attackTimer;
            _animationListener = animationListener;
        }

        public override void Update()
        {
            if (_animationListener.IsReadyForAttack && _attackTimer.IsReady)
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