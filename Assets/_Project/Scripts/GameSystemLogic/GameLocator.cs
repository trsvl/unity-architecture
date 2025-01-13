using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class GameLocator : MonoBehaviour
    {
        private readonly List<object> services = new();

        public void AddService(object service)
        {
            services.Add(service);
        }

        public void RemoveService(object service)
        {
            services.Remove(service);
        }

        public T GetService<T>()
        {
            foreach (var service in services)
            {
                if (service is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Service of type {typeof(T)} is not found!");
        }
    }
}