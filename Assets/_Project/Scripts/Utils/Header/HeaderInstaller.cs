using _Project.Scripts.GameSystemLogic;
using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class HeaderInstaller : MonoBehaviour, IInstaller
    {
        public void Register(Container container)
        {
            var header = Instantiate(Resources.Load<GameObject>("UI/Header")).GetComponent<Header>();
            header.Init();
            container.Bind(header, isSingleton: true);
        }
    }
}