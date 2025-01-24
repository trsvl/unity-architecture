using Unity.VisualScripting;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Attack
    {
        private readonly float _damage;


        public Attack(float damage)
        {
            _damage = damage;
        }

        public void Hit(IDamageable target)
        {
            target.TakeDamage(_damage);
        }
    }
}