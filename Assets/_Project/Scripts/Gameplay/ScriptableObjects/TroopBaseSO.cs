using _Project.Scripts.Gameplay.Troops;
using UnityEngine;

namespace _Project.Scripts.Gameplay.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TroopBase", menuName = "SO/Troops", order = 0)]
    public class TroopBaseSO : ScriptableObject
    {
        [field: SerializeField] public TroopBase TroopPrefab { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}