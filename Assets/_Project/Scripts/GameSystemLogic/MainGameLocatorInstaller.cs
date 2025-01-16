using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class MainGameLocatorInstaller : MonoBehaviour
    {
        [SerializeField] private GameLocator gameLocator;

        [SerializeField] private MonoBehaviour[] gameServices;


        private void Awake()
        {
            foreach (var service in gameServices)
            {
                gameLocator.AddService(service);
            }
        }
    }
}