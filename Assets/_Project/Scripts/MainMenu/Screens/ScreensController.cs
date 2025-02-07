using System;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.MainMenu.Screens
{
    public class ScreensController : IShopScreen, IBattleScreen, ICardsScreen, ITroopStatsScreen
    {
        private readonly ScreenFactory _factory;
        private MainMenuScreen _currentScreen;


        public ScreensController(ScreenFactory factory)
        {
            _factory = factory;
        }

        public void OnShopScreen()
        {
            EnableScreen();
        }

        public void OnBattleScreen()
        {
            EnableScreen();
        }

        public void OnCardsScreen()
        {
            EnableScreen();
        }

        public void OnTroopStatsScreen()
        {
            EnableScreen();
        }

        private async void EnableScreen()
        {
            MainMenuScreen newScreen = await _factory.SpawnScreen();
            
            if (_currentScreen != null)
            {
                _currentScreen.Disable();
                _factory.DespawnScreen(_currentScreen);
            }
            
            newScreen.gameObject.SetActive(false);
            
            _currentScreen = newScreen;
            _currentScreen.Load();
            _currentScreen.Enable();
            
            newScreen.gameObject.SetActive(true);
        }
    }
}