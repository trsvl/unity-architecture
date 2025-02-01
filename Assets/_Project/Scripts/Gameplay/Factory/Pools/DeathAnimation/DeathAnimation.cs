using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class DeathAnimation : PoolBase
    {
        private Animator _animator;
        private SpriteRenderer _sprite;


        public void Init(Animator animator, SpriteRenderer sprite)
        {
            _animator = animator;
            _sprite = sprite;
        }

        private void OnEnable()
        {
            if (_animator == null) return;

            Play();
        }

        private void Play()
        {
            _animator.enabled = true;
            _animator.Play("Dead", 0, 0f);

            float animLength = _animator.GetCurrentAnimatorStateInfo(0).length - 0.01f;

            DOTween.Sequence()
                .AppendInterval(animLength)
                .OnComplete(() =>
                {
                    _animator.enabled = false;
                    _sprite.DOFade(0f, 1f).OnComplete(() => { Factory.Instance.ReturnToPool(this); });
                });
        }

        private void OnDisable()
        {
            _sprite.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}