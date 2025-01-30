using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class AttackingTroopAnimationListener : MonoBehaviour, IAttackAnimationListener
    {
        private Animator _animator;
        public bool IsReadyForNextAnimation { get; private set; } = false;
        public bool IsReadyForAttack { get; private set; } = true;

        public void Init(Animator animator)
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
                    StartCoroutine(PlayAttack("Attack_1", 1f));
                    break;
            }
        }

        private void PlayAnimation(string animationName)
        {
            _animator.Play(animationName);
        }

        private IEnumerator PlayAttack(string animationName, float firstDelayValue)
        {
            IsReadyForNextAnimation = false;
            IsReadyForAttack = false;

            _animator.Play(animationName);
            float animationDuration = _animator.GetCurrentAnimatorStateInfo(0).length - 0.01f;
            float firstDelay = animationDuration * firstDelayValue;
            float secondDelay = animationDuration - firstDelay;

            yield return new WaitForSeconds(firstDelay);

            IsReadyForAttack = true;

            yield return new WaitForSeconds(secondDelay);

            IsReadyForNextAnimation = true;
        }

        private IEnumerator PlayFullAnimation(string animationName)
        {
            IsReadyForNextAnimation = false;

            _animator.Play(animationName);
            float animationDuration = _animator.GetCurrentAnimatorStateInfo(0).length - 0.01f;
            yield return new WaitForSeconds(animationDuration);

            IsReadyForNextAnimation = true;
        }
    }
}