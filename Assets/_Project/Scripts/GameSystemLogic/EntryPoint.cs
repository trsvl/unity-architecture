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
            GameObject gameObject = new GameObject();
            var monoBehaviourListeners = gameObject.AddComponent<MonoBehaviourListeners>();
            monoBehaviourListeners.enabled = false;

            container = new Container(monoBehaviourListeners);
        }
    }
}