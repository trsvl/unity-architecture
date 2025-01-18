using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    public class Container
    {
        private readonly Dictionary<Type, List<object>> _services = new();
        private readonly Dictionary<Type, object> _singletonServices = new();
        private readonly GameStatesListeners _gameStatesListeners = new();
        private readonly MonoBehaviourListeners _monoBehaviourListeners;


        public Container(MonoBehaviourListeners monoBehaviourListeners)
        {
            _monoBehaviourListeners = monoBehaviourListeners;
        }

        public void Bind<T>(T service, bool isSingleton = false)
        {
            if (service == null)
            {
                Debug.LogWarning("Service is null");
                return;
            }

            var type = typeof(T);

            if (_singletonServices.ContainsKey(type))
            {
                Debug.LogWarning("Service already registered as singleton: " + type);
                return;
            }

            if (isSingleton)
            {
                if (_services.ContainsKey(type))
                {
                    Debug.LogWarning("Service already registered as default service: " + type);
                    return;
                }

                _singletonServices.Add(type, service);
            }
            else
            {
                if (!_services.ContainsKey(type))
                {
                    _services.Add(type, new List<object>());
                }

                _services[type].Add(service);
            }

            _gameStatesListeners.AddListener(service);
            _monoBehaviourListeners.AddListener(service);
        }

        public T GetService<T>()
        {
            var type = typeof(T);

            if (_singletonServices.TryGetValue(type, out object singletonService))
            {
                return (T)singletonService;
            }

            if (_services.TryGetValue(type, out List<object> service))
            {
                if (service.Count > 1)
                {
                    Debug.LogWarning("Multiple services found. Type: " + type);
                    return default;
                }

                if (service.Count == 1)
                {
                    return (T)service[0];
                }
            }

            Debug.LogWarning("No services found. Type: " + type);
            return default;
        }

        public IEnumerable<T> GetAllServices<T>()
        {
            var type = typeof(T);

            if (_services.TryGetValue(type, out var services))
            {
                return (IEnumerable<T>)services;
            }

            Debug.LogWarning("No services found. Type: " + type);
            return default;
        }

        public void StartGame()
        {
            _monoBehaviourListeners.enabled = true;
            _gameStatesListeners.StartGame();
        }

        public void PauseGame()
        {
            _gameStatesListeners.PauseGame();
        }

        public void ResumeGame()
        {
            _gameStatesListeners.ResumeGame();
        }

        public void FinishGame()
        {
            _gameStatesListeners.FinishGame();
        }
    }
}