using System;
using System.Collections.Generic;

namespace _Project.Scripts.GameSystemLogic
{
    public class MainMenuStateObserver : IMainMenuStateObserver
    {
        public MainMenuState MainMenuState { get; private set; } = MainMenuState.BattleScreen;

        private readonly List<object> listeners = new();


        public void AddListener(object listener)
        {
            if (listener is IBattleScreen or ICardsScreen or IShopScreen or ITroopStatsScreen)
            {
                listeners.Add(listener);
            }
        }

        public void RemoveListener(object listener)
        {
            if (listener is IBattleScreen or ICardsScreen or IShopScreen or ITroopStatsScreen)
            {
                listeners.Remove(listener);
            }
        }

        public void BattleScreen()
        {
            NotifyListeners<IBattleScreen>(MainMenuState.BattleScreen, listener => listener.OnBattleScreen());
        }

        public void CardsScreen()
        {
            NotifyListeners<ICardsScreen>(MainMenuState.CardsScreen, listener => listener.OnCardsScreen());
        }

        public void ShopScreen()
        {
            NotifyListeners<IShopScreen>(MainMenuState.ShopScreen, listener => listener.OnShopScreen());
        }

        public void TroopStatsScreen()
        {
            NotifyListeners<ITroopStatsScreen>(MainMenuState.TroopStatsScreen,
                listener => listener.OnTroopStatsScreen());
        }

        private void NotifyListeners<T>(MainMenuState newState, Action<T> action) where T : class
        {
            MainMenuState = newState;

            foreach (var listener in listeners)
            {
                if (listener is T concreteListener)
                {
                    action(concreteListener);
                }
            }
        }
    }
}