using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class LevelDataController
    {
        public int CurrentLevel { get; set; }
        public int MaxLevels { get; set; }

        public void LoadData()
        {
            var currentLevelValue = PlayerPrefs.GetInt("CurrentLevel", 1);
            CurrentLevel = currentLevelValue;

            var maxLevelsValue = PlayerPrefs.GetInt("MaxLevelsValue", 1);
            MaxLevels = maxLevelsValue;
        }
        
    }
}