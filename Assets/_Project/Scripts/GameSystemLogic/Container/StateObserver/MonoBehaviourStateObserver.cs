using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    public class MonoBehaviourStateObserver : MonoBehaviour, IStateObserver
    {
        private readonly List<IUpdate> updateListeners = new();


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