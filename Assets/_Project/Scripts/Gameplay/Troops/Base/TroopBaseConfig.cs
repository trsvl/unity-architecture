using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public abstract class TroopBaseConfig : BaseConfig
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }


        protected void AssignDefaultVariables(TroopBase troop, StateMachine stateMachine)
        {
            var rb = troop.GetComponent<Rigidbody2D>();
            var collider = troop.GetComponent<Collider2D>();
            var spriteRenderer = troop.GetComponent<SpriteRenderer>();

            troop.AssignDefaultVariables(rb, collider, spriteRenderer, stateMachine);
        }
    }
}