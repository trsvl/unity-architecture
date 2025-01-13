using System.Collections.Generic;
using _Project.Scripts.GameSystemLogic.Interfaces;
using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class GameStatesListener : MonoBehaviour
    {
        public GameState GameState
        {
            get { return gameState; }
        }

        private GameState gameState = GameState.OFF;
        private readonly List<object> listeners = new List<object>();


        [ContextMenu("Start Game")]
        public void StartGame()
        {
            if (gameState != GameState.OFF)
            {
                Debug.LogWarning("Game state is " + gameState);
                return;
            }

            gameState = GameState.PLAY;

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
            if (gameState != GameState.PLAY)
            {
                Debug.LogWarning("Game state is " + gameState);
                return;
            }

            gameState = GameState.PAUSE;

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
            if (gameState != GameState.PAUSE)
            {
                Debug.LogWarning("Game state is " + gameState);
                return;
            }

            gameState = GameState.PLAY;

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
            if (gameState != GameState.PLAY)
            {
                Debug.LogWarning("Game state is " + gameState);
                return;
            }

            gameState = GameState.FINISH;

            foreach (var listener in listeners)
            {
                if (listener is IFinishGame concreteListener)
                {
                    concreteListener.FinishGame();
                }
            }
        }

        public void AddListener(object listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(object listener)
        {
            listeners.Remove(listener);
        }
    }
}