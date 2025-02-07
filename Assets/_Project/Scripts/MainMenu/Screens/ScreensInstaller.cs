using _Project.Scripts.GameSystemLogic;
using _Project.Scripts.MainMenu.Screens.Battle;
using UnityEngine;

namespace _Project.Scripts.MainMenu.Screens
{
    public class ScreensInstaller : MonoBehaviour, IInstaller
    {
        private const string _shopScreenPrefabName = "MainMenu/Screens/Shop Screen";
        private const string _battleScreenPrefabName = "MainMenu/Screens/Battle Screen";
        private const string _cardsScreenPrefabName = "MainMenu/Screens/Cards Screen";
        private const string _troopStatsScreenPrefabName = "MainMenu/Screens/Troop Stats Screen";
        

        public void Register(Container container)
        {
            var stateObserver = container.GetService<IMainMenuStateObserver>();

            var screenFactory = new ScreenFactory(stateObserver, _shopScreenPrefabName, _battleScreenPrefabName,
                _cardsScreenPrefabName, _troopStatsScreenPrefabName);

            var screensController = new ScreensController(screenFactory);

            container.Bind(screensController, isSingleton: true);
        }
    }
}