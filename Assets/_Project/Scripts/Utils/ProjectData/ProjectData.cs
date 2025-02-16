using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class ProjectData : Singleton<ProjectData>
    {
        public CurrencyDataController CurrencyDataController { get; private set; } = new();
        public LevelDataController LevelDataController { get; private set; } = new();


        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(this);
            LoadData();
        }

        private void LoadData()
        {
            PlayerPrefs.DeleteAll();
            
            CurrencyDataController.LoadData();
            LevelDataController.LoadData();
        }

        [ContextMenu("Add Currency")]
        public void AddCurrency()
        {
            CurrencyDataController.AddGoldCurrency(500);
        }

        [ContextMenu("Remove Currency")]
        public void RemoveCurrency()
        {
            CurrencyDataController.RemoveGoldCurrency(25);
        }
    }
}