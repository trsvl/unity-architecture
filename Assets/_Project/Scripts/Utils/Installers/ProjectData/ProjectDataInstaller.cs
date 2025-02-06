using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class ProjectDataInstaller : MonoBehaviour, IBootstrapInstaller
    {
        public void Load()
        {
            var projectData = Instantiate(Resources.Load("Bootstrap/ProjectData"));
        }
    }
}