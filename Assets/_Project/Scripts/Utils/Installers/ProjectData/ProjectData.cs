namespace _Project.Scripts.Utils.Installers
{
    public class ProjectData : Singleton<ProjectData>
    {
        public CurrencyDataController CurrencyDataController { get; private set; } = new();
        public TroopsDataController TroopsDataController { get; private set; } = new();


        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(this);
            LoadData();
        }

        private void LoadData()
        {
            CurrencyDataController.LoadData();
            TroopsDataController.LoadData();
        }
    }
}