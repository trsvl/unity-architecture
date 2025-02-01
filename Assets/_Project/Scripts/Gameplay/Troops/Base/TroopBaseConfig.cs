using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public abstract class TroopBaseConfig : BaseConfig
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}