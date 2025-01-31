using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.GameSystemLogic
{
    public class ProjectData : Singleton<ProjectData>
    {
        public int Currency { get; private set; }


        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(this);
            InitializeData();
        }

        private void InitializeData()
        {
            Currency = 228;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("gameplay");
                _ = SceneLoader.Instance.LoadScene(SceneLoader.Scene.Gameplay);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                print("mainmenu");
                _ = SceneLoader.Instance.LoadScene(SceneLoader.Scene.MainMenu);
            }
        }
    }
}