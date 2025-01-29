using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class AttackingTroopAnimationListener : IAnimationListener
    {
        private readonly Animator _animator;


        public AttackingTroopAnimationListener(Animator animator)
        {
            _animator = animator;
        }

        public void Notify(IMachineState action)
        {
            switch (action)
            {
                case Move:
                    _ = PlayAnimation("Run");
                    break;
                case Chase:
                    _ = PlayAnimation("Run");
                    break;
                case Attack:
                    _ = PlayAnimation("Attack_1");
                    break;
            }
        }

        public void NotifyExit(IMachineState action)
        {
        }

        private async Task  PlayAnimation(string animationName)
        {
            await Task.Yield();
            _animator.Play(animationName);
        }
    }
}