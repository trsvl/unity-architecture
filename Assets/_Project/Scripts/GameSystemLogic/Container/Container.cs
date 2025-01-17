using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class Container
    {
        private readonly GameContext gameContext = new();
        private readonly MonoBehaviourListeners _monoBehaviourListeners;


        public Container(MonoBehaviourListeners monoBehaviourListeners)
        {
            _monoBehaviourListeners = monoBehaviourListeners;
        }

        public Container Bind<T>(T service)
        {
            if (service == null)
            {
                Debug.LogWarning("Service is null");
                return this;
            }

            gameContext.AddListener(service);
            _monoBehaviourListeners.AddListener(service);

            return this;
        }

        public void StartGame()
        {
            _monoBehaviourListeners.enabled = true;
            gameContext.StartGame();
        }
    }
}