using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.MainMenu.Screens
{
    public class ScreenFactory
    {
        private readonly IMainMenuStateObserver _stateObserver;
        private readonly Dictionary<MainMenuState, string> _screens = new();


        public ScreenFactory(IMainMenuStateObserver stateObserver, string shopScreenPrefabName,
            string battleScreenPrefabName,
            string cardsScreenPrefabName, string troopStatsScreenPrefabName)
        {
            _stateObserver = stateObserver;

            _screens.Add(MainMenuState.ShopScreen, shopScreenPrefabName);
            _screens.Add(MainMenuState.BattleScreen, battleScreenPrefabName);
            _screens.Add(MainMenuState.CardsScreen, cardsScreenPrefabName);
            _screens.Add(MainMenuState.TroopStatsScreen, troopStatsScreenPrefabName);
        }


        public async Task<MainMenuScreen> SpawnScreen()
        {
            if (!_screens.TryGetValue(_stateObserver.MainMenuState, out var screenPath)) return null;

            ResourceRequest request = Resources.LoadAsync<MainMenuScreen>(screenPath);
            while (!request.isDone)
            {
                await Task.Yield();
            }

            MainMenuScreen scene = Object.Instantiate(request.asset as MainMenuScreen);
            return scene;
        }

        public void DespawnScreen(MainMenuScreen screen)
        {
            Object.Destroy(screen.gameObject);
        }
    }
}