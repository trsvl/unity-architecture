using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] _installers;

        private void Awake()
        {
            foreach (var installer in _installers)
            {
                if (installer != null && installer is IInstaller installerComponent)
                {
                    installerComponent.Register().Wait();
                }
            }
        }
    }
}