using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    public class GameStatesListeners
    {
        public GameState GameState { get; private set; } = GameState.OFF;

        private readonly List<object> listeners = new List<object>();


        public void AddListener(object listener)
        {
            if (listener is IStartGame or IPauseGame or IResumeGame or IFinishGame)
            {
                listeners.Add(listener);
            }
        }

        public void RemoveListener(object listener)
        {
            if (listener is IStartGame or IPauseGame or IResumeGame or IFinishGame)
            {
                listeners.Remove(listener);
            }
        }

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            if (GameState != GameState.OFF)
            {
                Debug.LogWarning("Game state is " + GameState);
                return;
            }

            GameState = GameState.PLAY;

            foreach (var listener in listeners)
            {
                if (listener is IStartGame concreteListener)
                {
                    concreteListener.StartGame();
                }
            }
        }

        [ContextMenu("Pause Game")]
        public void PauseGame()
        {
            if (GameState != GameState.PLAY)
            {
                Debug.LogWarning("Game state is " + GameState);
                return;
            }

            GameState = GameState.PAUSE;

            foreach (var listener in listeners)
            {
                if (listener is IPauseGame concreteListener)
                {
                    concreteListener.PauseGame();
                }
            }
        }

        [ContextMenu("Resume Game")]
        public void ResumeGame()
        {
            if (GameState != GameState.PAUSE)
            {
                Debug.LogWarning("Game state is " + GameState);
                return;
            }

            GameState = GameState.PLAY;

            foreach (var listener in listeners)
            {
                if (listener is IResumeGame concreteListener)
                {
                    concreteListener.ResumeGame();
                }
            }
        }

        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            if (GameState != GameState.PLAY)
            {
                Debug.LogWarning("Game state is " + GameState);
                return;
            }

            GameState = GameState.FINISH;

            foreach (var listener in listeners)
            {
                if (listener is IFinishGame concreteListener)
                {
                    concreteListener.FinishGame();
                }
            }
        }
    }
}