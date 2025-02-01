using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    [CreateAssetMenu(fileName = "TroopDeathAnimation", menuName = "SO/Effects/TroopDeathAnimation", order = 0)]
    public class DeathAnimationConfig : BaseConfig
    {
        public override PoolBase OnCreate()
        {
            var obj = Instantiate(Prefab);
            var deathAnimation = obj.GetComponent<DeathAnimation>();

            var animator = deathAnimation.GetComponent<Animator>();
            var sprite = animator.GetComponent<SpriteRenderer>();

            deathAnimation.Init(animator, sprite);

            obj.SetActive(false);
            return deathAnimation;
        }
    }
}