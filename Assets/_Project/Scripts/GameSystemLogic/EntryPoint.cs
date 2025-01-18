using System;
using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class EntryPoint : MonoBehaviour
    {
        private Container container;
        [SerializeField] private MonoBehaviour[] _installers;

        private void Awake()
        {
            InitializeContainer();

            print("Start EntryPoint");
            foreach (var installer in _installers)
            {
                if (installer != null && installer is IInstaller installerComponent)
                {
                    installerComponent.Register(container);
                }
            }

            container.StartGame();
        }

        private void InitializeContainer()
        {
            GameObject gameObj = new GameObject();
            var monoBehaviourListeners = gameObj.AddComponent<MonoBehaviourListeners>();
            monoBehaviourListeners.enabled = false;

            container = new Container(monoBehaviourListeners);
        }
    }
}