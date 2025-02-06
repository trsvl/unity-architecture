using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class EntryPoint : MonoBehaviour
    {
        protected readonly Container container = new();

        [SerializeField] private MonoBehaviour _firstInstaller;
        [SerializeField] private MonoBehaviour[] _installers;


        protected virtual void Awake()
        {
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
                else
                {
                    Debug.LogError($"{nameof(installer)} is not a {nameof(IInstaller)} or null");
                    return;
                }
            }
        }
    }
}