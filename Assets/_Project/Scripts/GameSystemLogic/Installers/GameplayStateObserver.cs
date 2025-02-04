using System;
using System.Collections.Generic;

namespace _Project.Scripts.GameSystemLogic
{
    public class GameplayStateObserver : IGameplayStateObserver
    {
        public GameState GameState { get; private set; } = GameState.OFF;

        private readonly List<object> listeners = new();


        public void AddListener(object listener)
        {
            if (listener is IStartGame or IPauseGame or IResumeGame or IFinishGame or ILoseGame)
            {
                listeners.Add(listener);
            }
        }

        public void RemoveListener(object listener)
        {
            if (listener is IStartGame or IPauseGame or IResumeGame or IFinishGame or ILoseGame)
            {
                listeners.Remove(listener);
            }
        }

        public void StartGame()
        {
            NotifyListeners<IStartGame>(GameState == GameState.OFF, GameState.PLAY, (listener) => listener.StartGame());
        }

        public void PauseGame()
        {
            NotifyListeners<IPauseGame>(GameState == GameState.PLAY, GameState.PAUSE,
                (listener) => listener.PauseGame());
        }

        public void ResumeGame()
        {
            NotifyListeners<IResumeGame>(GameState == GameState.PAUSE, GameState.PLAY,
                (listener) => listener.ResumeGame());
        }

        public void FinishGame()
        {
            NotifyListeners<IFinishGame>(GameState == GameState.PLAY, GameState.FINISH,
                (listener) => listener.FinishGame());
        }

        public void LoseGame()
        {
            NotifyListeners<ILoseGame>(GameState == GameState.PLAY, GameState.LOSE,
                (listener) => listener.LoseGame());
        }

        private void NotifyListeners<T>(bool condition, GameState newState, Action<T> action) where T : class
        {
            if (!condition) return;

            GameState = newState;

            foreach (var listener in listeners)
            {
                action(listener as T);
            }
        }
    }
}