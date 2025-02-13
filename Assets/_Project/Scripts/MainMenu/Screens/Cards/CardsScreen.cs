using System.Collections.Generic;
using _Project.Scripts.Gameplay.Troops.Base;
using _Project.Scripts.Utils.Installers;
using UnityEngine;

namespace _Project.Scripts.MainMenu.Screens
{
    public class CardsScreen : MainMenuScreen
    {
        public TroopCard TroopCardPrefab;


        public override void Load()
        {
            base.Load();

            var troopsDataController = ProjectData.Instance.TroopsDataController;
            TroopBaseData[] playerTroops = troopsDataController.LoadPlayerTroops();
            var allConfigs = troopsDataController.SO.AllTroopConfigs;

            var availableTroops = new List<TroopBaseData>();
            var unavailableTroops = new List<TroopBaseConfig>();

            for (int i = 0; i < allConfigs.Length; i++)
            {
                if (playerTroops[i] != null && (allConfigs[playerTroops[i].TroopConfigIndex] == allConfigs[i]))
                {
                    availableTroops.Add(playerTroops[i]);
                }
                else
                {
                    unavailableTroops.Add(allConfigs[i]);
                }
            }

            foreach (TroopBaseData data in availableTroops)
            {
                var config = allConfigs[data.TroopConfigIndex];
                var troopCard = Instantiate(TroopCardPrefab);
                ulong price = config.Price + (ulong)(config.PriceScale * (data.Level - 1));
                var sprite = config.Prefab.GetComponent<SpriteRenderer>().sprite;
                troopCard.Init(data.Level, price, sprite, true);
            }

            foreach (TroopBaseConfig config in unavailableTroops)
            {
                var troopCard = Instantiate(TroopCardPrefab);
                var sprite = config.Prefab.GetComponent<SpriteRenderer>().sprite;
                troopCard.Init(0, 0, sprite, false);
            }
        }

        public override void Enable()
        {
        }

        public override void Disable()
        {
        }
    }
}