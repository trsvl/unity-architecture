using UnityEngine;

namespace _Project.Scripts.GameSystemLogic.Installers
{
    public class MainMenuStateObserverInstaller : MonoBehaviour, IInstaller, IStateObserverInstaller
    {
        private IMainMenuStateObserver _stateObserver;


        public IStateObserver RegisterStateObserver()
        {
            var observer = new MainMenuStateObserver();
            _stateObserver = observer;
            return _stateObserver;
        }

        public void Register(Container container)
        {
            container.Bind(_stateObserver, isSingleton: true);
        }
    }
}