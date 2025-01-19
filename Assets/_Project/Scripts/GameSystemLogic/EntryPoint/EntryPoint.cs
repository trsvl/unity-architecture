using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class EntryPoint : MonoBehaviour
    {
        protected Container container = new();

        [SerializeField] private MonoBehaviour _firstInstaller;
        [SerializeField] private MonoBehaviour[] _installers;


        protected virtual void Awake()
        {
            print("Start EntryPoint");

            if (_firstInstaller is IFirstInstaller stateObserverInstaller)
            {
                stateObserverInstaller.Register(container);
            }

            foreach (var installer in _installers)
            {
                if (installer != null && installer is IInstaller installerComponent)
                {
                    installerComponent.Register(container);
                }
                else if (installer is not IInstaller)
                {
                    Debug.LogError($"{nameof(IInstaller)} is not a {nameof(IInstaller)}");
                    return;
                }
            }
        }
    }
}