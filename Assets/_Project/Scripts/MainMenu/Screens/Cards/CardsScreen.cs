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
            TroopBaseData[] availableTroops = troopsDataController.LoadPlayerTroops();
            var allConfigs = troopsDataController.SO.AllTroopConfigs;

            foreach (TroopBaseData t in availableTroops)
            {
                if (allConfigs.Contains(t.TroopConfig))
                {
                    var troopCard = Instantiate(TroopCardPrefab);
                    ulong price = t.TroopConfig.Price + (ulong)(t.TroopConfig.PriceScale * (t.Level - 1));
                    var sprite = t.TroopConfig.Prefab.GetComponent<SpriteRenderer>().sprite;
                    troopCard.Init(t.Level, price, sprite, true);
                }
                else
                {
                    var troopCard = Instantiate(TroopCardPrefab);
                    var sprite = t.TroopConfig.Prefab.GetComponent<SpriteRenderer>().sprite;
                    troopCard.Init(0, 0, sprite, false);
                }
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