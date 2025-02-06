using _Project.Scripts.GameSystemLogic;
using _Project.Scripts.Utils.Currency;
using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class HeaderInstaller : MonoBehaviour, IInstaller
    {
        
        
        public void Register(Container container)
        {
            var header = Instantiate(Resources.Load<GameObject>("UI/Header")).GetComponent<Header>();
        }
    }
}