using TMPro;
using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class LevelDataController
    {
        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value;
                _levelText?.SetText($"Battle {_currentLevel}");
            }
        }

        public int MaxLevels { get; private set; }

        private int _currentLevel;
        private TextMeshProUGUI _levelText;


        public void LoadData()
        {
            var currentLevelValue = PlayerPrefs.GetInt("CurrentLevel", 1);
            CurrentLevel = currentLevelValue;

            var maxLevelsValue = PlayerPrefs.GetInt("MaxLevelsValue", 5);
            MaxLevels = maxLevelsValue;
        }

        public void BindCurrentLevelText(TextMeshProUGUI textMeshProUGUI)
        {
            _levelText = textMeshProUGUI;
            _levelText.SetText($"Battle {_currentLevel}");
        }
    }
}