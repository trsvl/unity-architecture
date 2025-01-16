using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class ServiceLocator
    {
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();


        public T GetService<T>()
        {
            var type = typeof(T);

            if (services.TryGetValue(type, out object service))
            {
                return (T)service;
            }

            Debug.LogError($"No service registered for {type}");
            return default(T);
        }

        public void Register<T>(T service)
        {
            var type = typeof(T);

            if (services.ContainsKey(type))
            {
                Debug.LogWarning($"Service {service.GetType().Name} is already registered");
                return;
            }

            services[typeof(T)] = service;
        }

        public void UnregisterService<T>()
        {
            var type = typeof(T);

            if (services.ContainsKey(type))
            {
                services.Remove(type);
            }
        }
    }
}