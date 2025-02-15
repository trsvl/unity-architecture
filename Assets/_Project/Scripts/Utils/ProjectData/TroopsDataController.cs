using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Gameplay.Troops.Base;
using _Project.Scripts.Utils.DTOs;
using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class TroopsDataController
    {
        public AllTroopsSO SO { get; private set; }

        private readonly PlayerTroopDTO[] testData =
        {
            new() { level = 1, isSelected = true, Type = PoolType.Knight },
        };


        public void LoadData()
        {
            SO = Resources.Load<AllTroopsSO>("SO/AllTroops");
            SaveJSON(); //!!!
        }

        public TroopData[] LoadPlayerTroops()
        {
            string json = PlayerPrefs.GetString("PlayerTroops");
            Debug.Log(json);
            var playerTroopsDTO = JsonUtility.FromJson<PlayerTroopDTO[]>(json);
            TroopData[] playerTroops = new TroopData[playerTroopsDTO.Length];

            for (int i = 0; i < playerTroops.Length; i++)
            {
                var troopConfigIndex = Array.FindIndex(SO.AllTroopConfigs,
                    config => config.PoolType == playerTroopsDTO[i].Type);

                TroopData troopData = new()
                {
                    Level = playerTroopsDTO[i].level,
                    IsSelected = playerTroopsDTO[i].isSelected,
                    Config = SO.AllTroopConfigs[troopConfigIndex],
                };

                playerTroops[i] = troopData;
            }

            return playerTroops;
        }

        private void SaveJSON()
        {
            string json = JsonUtility.ToJson(testData);
            PlayerPrefs.SetString("PlayerTroops", json);
        }
    }
}