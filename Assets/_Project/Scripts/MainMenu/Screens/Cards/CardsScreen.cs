using System;
using System.Collections.Generic;
using _Project.Scripts.Gameplay.Troops.Base;
using _Project.Scripts.MainMenu.Screens.Cards;
using _Project.Scripts.Utils.Installers;
using UnityEngine;

namespace _Project.Scripts.MainMenu.Screens
{
    public class CardsScreen : MainMenuScreen
    {
        public TroopCard TroopCardPrefab;

        private CardSorting _cardSorting;
        private List<TroopData> _allTroops;


        public override void Load()
        {
            base.Load();

            var troopsDataController = ProjectData.Instance.TroopsDataController;

            _cardSorting = new CardSorting();

            TroopData[] playerTroops = troopsDataController.LoadPlayerTroops();

            var allConfigs = troopsDataController.SO.AllTroopConfigs;

            _allTroops = new List<TroopData>(allConfigs.Length);

            for (int i = 0; i < allConfigs.Length; i++)
            {
                if (playerTroops[i] != null && (playerTroops[i].Config == allConfigs[i]))
                {
                    var troopData = playerTroops[i];
                    _allTroops.Add(troopData);
                }
                else
                {
                    var troopData = new TroopData()
                    {
                        Level = 0,
                        IsSelected = false,
                        Config = allConfigs[i],
                    };
                    _allTroops.Add(troopData);
                }
            }

            SortByLevel();
        }

        private void SpawnTroopCard(TroopData troopData, CurrencyDataController currencyDataController)
        {
            var troopCard = Instantiate(TroopCardPrefab);
            var config = troopData.Config;
            ulong price = config.Price + (ulong)(config.PriceScale * (troopData.Level - 1));
            var sprite = config.Prefab.GetComponent<SpriteRenderer>().sprite;

            troopCard.Init(troopData.Level, price, sprite, currencyDataController, troopData, troopData.Level > 0);
        }

        private void SortByLevel()
        {
            _cardSorting.SortByLevel(_allTroops);

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var troopData in _allTroops)
            {
                SpawnTroopCard(troopData, ProjectData.Instance.CurrencyDataController);
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