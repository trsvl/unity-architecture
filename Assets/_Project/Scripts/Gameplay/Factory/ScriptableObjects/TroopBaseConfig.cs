using UnityEngine;

namespace _Project.Scripts.Gameplay.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TroopBase", menuName = "SO/Troops/Base", order = 0)]
    public class TroopBaseConfig : BaseConfig
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}