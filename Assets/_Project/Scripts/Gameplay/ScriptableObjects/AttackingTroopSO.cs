using _Project.Scripts.Gameplay.Troops;
using UnityEngine;

namespace _Project.Scripts.Gameplay.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AttackingTroop", menuName = "SO/Troops", order = 0)]
    public class AttackingTroopSO : TroopBaseSO
    {
        [field: SerializeField] public new AttackingTroop TroopPrefab { get; private set; }
        [field: SerializeField] public float AttackDamage { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
    }
}