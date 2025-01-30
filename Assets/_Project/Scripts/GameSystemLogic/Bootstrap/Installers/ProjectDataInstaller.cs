using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class ProjectDataInstaller : MonoBehaviour, IBootstrapInstaller
    {
        public void Load()
        {
            var projectData = Instantiate(Resources.Load("Bootstrap/ProjectData"));
        }
    }
}