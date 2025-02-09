using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Utils.Installers
{
    public class Header : MonoBehaviour, IBattleScreen, ICardsScreen, ITroopStatsScreen
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TextMeshProUGUI _goldCurrencyText;
        [SerializeField] private TextMeshProUGUI _currentScreenText;
        [SerializeField] private TextMeshProUGUI _diamondCurrencyText;


        public void Init()
        {
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = Camera.main;

            var currencyController = ProjectData.Instance.CurrencyDataController;
            var levelController = ProjectData.Instance.LevelDataController;

            currencyController.BindGoldCurrencyText(_goldCurrencyText);
            currencyController.BindDiamondCurrencyText(_diamondCurrencyText);
            levelController.BindCurrentLevelText(_currentScreenText);

            if (SceneManager.GetActiveScene().name == SceneName.Gameplay.ToString()) OnBattleScreen();
        }

        public void OnBattleScreen()
        {
            int level = ProjectData.Instance.LevelDataController.CurrentLevel;
            _currentScreenText.SetText($"Battle {level}");
        }

        public void OnCardsScreen()
        {
            var troopController = ProjectData.Instance.TroopsDataController;
            _currentScreenText.SetText($"Cards");
        }

        public void OnTroopStatsScreen()
        {
            _currentScreenText.SetText($"Troop Stats");
        }
    }
}