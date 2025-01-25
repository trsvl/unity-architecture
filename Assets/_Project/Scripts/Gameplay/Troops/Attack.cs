using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Attack : BaseMachineState
    {
        private readonly Troop _troop;
        private readonly float _damage;


        public Attack(Troop troop, float damage)
        {
            _troop = troop;
            _damage = damage;
        }

        public override void OnEnter()
        {
            Debug.Log("attack");
        }

        public override void Update()
        {
            //timer
            //Hit()
        }

        public void Hit()
        {
            _troop.ClosestDamageableTarget.TakeDamage(_damage);
        }
    }
}