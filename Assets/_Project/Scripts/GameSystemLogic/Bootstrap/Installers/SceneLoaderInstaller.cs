using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class SceneLoaderInstaller : MonoBehaviour, IBootstrapInstaller
    {
        public void Load()
        {
            var sceneLoader = Instantiate(Resources.Load("Bootstrap/SceneLoader"));
        }
    }
}