using System;
using System.Collections.Generic;
using _Project.Scripts.Gameplay.Troops.Base;
using _Project.Scripts.Utils.DTOs;
using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class TroopsDataController
    {
        public List<TroopData> TroopArmy { get; private set; }

        private AllTroopsSO allTroopsSO;
        private readonly HashSet<PoolType> currentArmy = new() { PoolType.Knight }; //!!!

        private readonly PlayerTroopDTO[] testData =
        {
            new() { level = 1, Type = PoolType.Knight },
        }; //!!!


        public void LoadData()
        {
            allTroopsSO = Resources.Load<AllTroopsSO>("SO/AllTroops");
            SaveJSON(); //!!!
        }

        public TroopData[] LoadAllTroops()
        {
            string json = PlayerPrefs.GetString("PlayerTroops");
            var playerTroopsDTO = JsonUtility.FromJson<PlayerTroopDTO[]>(json);
            Debug.Log(json);

            var allConfigs = allTroopsSO.configs;
            TroopData[] allTroops = new TroopData[allConfigs.Length];
            TroopArmy = new List<TroopData>();

            for (int i = 0; i < allConfigs.Length; i++)
            {
                var troopIndex = Array.FindIndex(allConfigs,
                    config => config.PoolType == playerTroopsDTO[i]?.Type);

                if (troopIndex != -1)
                {
                    var config = allConfigs[troopIndex];
                    var isSelected = currentArmy.Contains(config.PoolType);

                    TroopData troopData = new()
                    {
                        Level = playerTroopsDTO[i].level,
                        IsSelected = isSelected,
                        Config = config
                    };

                    if (isSelected) TroopArmy.Add(troopData);

                    allTroops[i] = troopData;
                }
                else
                {
                    var troopData = new TroopData()
                    {
                        Level = 0,
                        IsSelected = false,
                        Config = allConfigs[i],
                    };

                    allTroops[i] = troopData;
                }
            }

            return allTroops;
        }

        private void SaveJSON()
        {
            string json = JsonUtility.ToJson(testData);
            PlayerPrefs.SetString("PlayerTroops", json);
        }
    }
}