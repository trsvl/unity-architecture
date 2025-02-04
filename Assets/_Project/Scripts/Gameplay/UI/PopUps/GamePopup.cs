using _Project.Scripts.GameSystemLogic;
using _Project.Scripts.Utils.UI.Buttons;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts.Gameplay.UI.PopUps
{
    public class GamePopup : IPauseGame, IResumeGame, IFinishGame, ILoseGame
    {
        private readonly GameObject _popUp;
        private readonly TextButton _firstButton;
        private readonly TextButton _secondButton;
        private readonly IGameplayStateObserver _gameplayStateObserver;


        public GamePopup(GameObject popUp, TextButton firstButton, TextButton secondButton,
            IGameplayStateObserver gameplayStateObserver)
        {
            _popUp = popUp;
            _firstButton = firstButton;
            _secondButton = secondButton;
            _gameplayStateObserver = gameplayStateObserver;
        }

        public void PauseGame()
        {
            _popUp.SetActive(true);
            AssignButton(_firstButton, ResumeGameCLick, "Resume game");
            AssignButton(_secondButton, MainMenuClick, "Main menu");
        }

        public void FinishGame()
        {
            _popUp.SetActive(true);
            AssignButton(_firstButton, RestartGameClick, "Next level");
            AssignButton(_secondButton, MainMenuClick, "Main menu");
        }

        public void LoseGame()
        {
            _popUp.SetActive(true);
            AssignButton(_firstButton, RestartGameClick, "Try again");
            AssignButton(_secondButton, MainMenuClick, "Main menu");
        }

        public void ResumeGame()
        {
            _popUp.SetActive(false);
            _firstButton.RemoveListeners();
            _secondButton.RemoveListeners();
        }

        private void AssignButton(TextButton button, UnityAction listener, string text)
        {
            button.Set(listener, text);
        }

        private void ResumeGameCLick()
        {
            _gameplayStateObserver.ResumeGame();
        }

        private void RestartGameClick()
        {
            _ = SceneLoader.Instance.LoadScene(SceneName.Gameplay);
        }

        private void MainMenuClick()
        {
            _ = SceneLoader.Instance.LoadScene(SceneName.MainMenu);
        }
    }
}