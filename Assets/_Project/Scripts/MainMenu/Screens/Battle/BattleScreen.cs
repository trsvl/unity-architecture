using _Project.Scripts.Utils.Installers;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.MainMenu.Screens.Battle
{
    public class BattleScreen : MainMenuScreen
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _battleButton;
        [SerializeField] private Button _leftPointerButton;
        [SerializeField] private Button _rightPointerButton;

        private BattleScreenPointers _battleScreenPointers;


        public override void Load()
        {
            base.Load();
            var levelDataController = ProjectData.Instance.LevelDataController;
            _battleScreenPointers =
                new BattleScreenPointers(_leftPointerButton, _rightPointerButton, levelDataController);
        }

        public override void Enable()
        {
            // _settingsButton.onClick.AddListener();

            _battleButton.onClick.AddListener(() => _ = SceneLoader.Instance.LoadScene(SceneName.Gameplay));

            _leftPointerButton.onClick.AddListener(_battleScreenPointers.LeftPointerClickListener);
            _rightPointerButton.onClick.AddListener(_battleScreenPointers.RightPointerClickListener);
        }

        public override void Disable()
        {
            _battleButton.onClick.RemoveAllListeners();
            _leftPointerButton.onClick.RemoveAllListeners();
            _rightPointerButton.onClick.RemoveAllListeners();

            gameObject.SetActive(false);
        }
    }
}