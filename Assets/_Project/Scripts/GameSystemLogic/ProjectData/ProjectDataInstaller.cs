using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class ProjectDataInstaller : MonoBehaviour, IInstaller
    {
        public void Register(Container container)
        {
            var projectData = Instantiate(Resources.Load("ProjectData")) as GameObject;
        }
    }
}