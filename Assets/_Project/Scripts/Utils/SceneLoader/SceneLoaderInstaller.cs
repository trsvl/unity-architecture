using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class SceneLoaderInstaller : MonoBehaviour, IBootstrapInstaller
    {
        public void Load()
        {
            var sceneLoader = Instantiate(Resources.Load("Bootstrap/SceneLoader"));
        }
    }
}