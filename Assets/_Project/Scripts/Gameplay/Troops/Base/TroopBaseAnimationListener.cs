using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops.Base
{
    public class TroopBaseAnimationListener : IAttackAnimationListener
    {
        private readonly Animator _animator;

        public bool IsReadyForAttack { get; private set; } = true;


        public TroopBaseAnimationListener(Animator animator)
        {
            _animator = animator;
        }

        public void Notify(IStateNode action)
        {
            switch (action)
            {
                case Idle:
                    PlayAnimation("Idle");
                    break;
                case Move:
                    PlayAnimation("Run");
                    break;
                case Chase:
                    PlayAnimation("Run");
                    break;
                case Attack:
                    PlayAttack("Attack_1", 0.7f);
                    break;
            }
        }

        private void PlayAnimation(string animationName)
        {
            _animator.Play(animationName);
        }

        private void PlayAttack(string animationName, float firstDelayValue)
        {
            IsReadyForAttack = false;
            
            _animator.Play(animationName);
            float animationDuration = _animator.GetCurrentAnimatorStateInfo(0).length - 0.01f;
            float firstDelay = animationDuration * firstDelayValue;
            float secondDelay = animationDuration - firstDelay;

            DOVirtual.DelayedCall(firstDelay, () => IsReadyForAttack = true);
            DOVirtual.DelayedCall(secondDelay, () =>
            {
                //
            });
        }
    }
}