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
            SaveJSON();
        }

        public TroopBaseData[] LoadPlayerTroops()
        {
            string json = PlayerPrefs.GetString("PlayerTroops");
            Debug.Log(json);
            var playerTroopsDTO = JsonUtility.FromJson<PlayerTroopDTO[]>(json);
            TroopBaseData[] playerTroops = new TroopBaseData[playerTroopsDTO.Length];

            for (int i = 0; i < playerTroops.Length; i++)
            {
                TroopBaseData troopBaseData = new()
                {
                    Level = playerTroopsDTO[i].level,
                    IsSelected = playerTroopsDTO[i].isSelected,
                    TroopConfigIndex = Array.FindIndex(SO.AllTroopConfigs,
                        config => config.PoolType == playerTroopsDTO[i].Type),
                };

                playerTroops[i] = troopBaseData;
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