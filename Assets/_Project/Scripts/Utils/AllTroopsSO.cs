using System.Collections.Generic;
using _Project.Scripts.Gameplay.Troops.Base;
using UnityEngine;

namespace _Project.Scripts.Utils
{
    [CreateAssetMenu(fileName = "AllTroopsSO", menuName = "SO/TroopList/AllTroopsSO", order = 0)]
    public class AllTroopsSO : ScriptableObject
    {
        public List<TroopBaseConfig> AllTroopConfigs;
        public Dictionary<PoolType, TroopBaseConfig> AllTroops { get; private set; } = new();

        private void Awake()
        {
            foreach (var troopBaseConfig in AllTroopConfigs)
            {
                AllTroops.Add(troopBaseConfig.PoolType, troopBaseConfig);
            }
        }
    }
}