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
        private TroopData[] _allTroops;


        public override void Load()
        {
            base.Load();

            _cardSorting = new CardSorting();

            var troopsDataController = new TroopsDataController();
            _allTroops = troopsDataController.LoadAllTroops();

            SortByLevel();
        }

        private void SpawnTroopCard(TroopData troopData, CurrencyDataController currencyDataController)
        {
            var troopCard = Instantiate(TroopCardPrefab);
            var config = troopData.Config;
            ulong price = config.Price + (ulong)(config.PriceScale * (troopData.Level - 1));
            var sprite = config.Prefab.GetComponent<SpriteRenderer>().sprite;

            troopCard.Init(troopData.Level, price, sprite, currencyDataController, troopData, troopData.IsSelected,
                troopData.Level > 0);
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