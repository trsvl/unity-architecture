using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    public class MonoBehaviourStateObserver : MonoBehaviour, IStateObserver, IStartGame
    {
        private readonly List<IUpdate> updateListeners = new();


        private void Awake()
        {
            print(name + " Awake");
            this.gameObject.SetActive(false);
        }

        public void StartGame()
        {
            this.gameObject.SetActive(true);
            print(name + " has started");
        }

        public void AddListener(object listener)
        {
            if (listener is IUpdate concreteListener)
            {
                updateListeners.Add(concreteListener);
            }
        }

        public void RemoveListener(object listener)
        {
            if (listener is IUpdate concreteListener)
            {
                updateListeners.Remove(concreteListener);
            }
        }

        private void Update()
        {
            foreach (var listener in updateListeners)
            {
                listener.Update();
            }
        }
    }
}