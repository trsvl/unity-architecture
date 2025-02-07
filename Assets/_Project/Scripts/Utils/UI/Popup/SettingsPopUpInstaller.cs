using _Project.Scripts.Gameplay.UI.Popup;
using _Project.Scripts.GameSystemLogic;
using _Project.Scripts.Utils.UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Utils.UI.Popup
{
    public class SettingsPopUpInstaller : MonoBehaviour, IInstaller //!!!
    {
        [SerializeField] private GameObject _gamePopup;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private TextButton _firstButton;
        [SerializeField] private TextButton _secondButton;
        
        
        public void Register(Container container)
        {
            var gameplayStateObserver = container.GetService<GameplayStateObserver>();
            var gamePopup = new GamePopup(_gamePopup, _firstButton, _secondButton, gameplayStateObserver);
            container.Bind(gamePopup, isSingleton: true);
            
            _settingsButton.onClick.AddListener(gameplayStateObserver.PauseGame);
        }
  
        private void OnDestroy()
        {
            _settingsButton.onClick.RemoveAllListeners();
        }
    }
}