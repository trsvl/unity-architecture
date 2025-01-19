using UnityEngine;

namespace _Project.Scripts.GameSystemLogic.Installers
{
    public class GameplayStateObserverInstaller : MonoBehaviour, IInstaller, IStateObserverInstaller
    {
        private GameplayStateObserver _stateObserver;


        public IStateObserver RegisterStateObserver()
        {
            var gameplayStateObserver = new GameplayStateObserver();
            _stateObserver = gameplayStateObserver;
            return _stateObserver;
        }

        public void Register(Container container)
        {
            container.Bind(_stateObserver, isSingleton: true);
        }
    }
}