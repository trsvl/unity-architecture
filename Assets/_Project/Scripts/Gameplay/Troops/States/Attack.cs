using _Project.Scripts.Gameplay.Troops.Base;
using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Attack : TroopStateNode
    {
        private new readonly TroopBase _troop;
        private readonly StopWatchTimer _attackTimer;
        private readonly IAttackAnimationListener _animationListener;


        public Attack(IAttackAnimationListener animationListener, TroopBase troop, StopWatchTimer attackTimer) :
            base(animationListener, troop)
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
            _troop.ClosestDamageableTarget.TakeDamage(_troop.Config.Damage);
        }
    }
}