using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Attack : BaseMachineState
    {
        private readonly AttackingTroop _troop;


        public Attack(AttackingTroop troop)
        {
            _troop = troop;
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

        private void Hit()
        {
            _troop.ClosestDamageableTarget.TakeDamage(_troop.Config.AttackDamage);
        }
    }
}