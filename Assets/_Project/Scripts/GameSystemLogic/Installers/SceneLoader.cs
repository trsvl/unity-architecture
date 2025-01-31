using System.Threading.Tasks;
using _Project.Scripts.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.GameSystemLogic
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        [SerializeField] private GameObject loadingScreen;

        public enum Scene
        {
            MainMenu,
            Gameplay
        }


        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(this);
        }

        public async Task LoadScene(Scene scene)
        {
            loadingScreen.SetActive(true);

            var sceneName = scene.ToString();
            print("loading scene: " + sceneName);
            await Task.Delay(2 * 1000);

            AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneName);

            if (loadingScene == null)
            {
                Debug.LogError($"Failed to load scene {sceneName}");
                return;
            }

            loadingScene.allowSceneActivation = false;

            while (!loadingScene.isDone)
            {
                if (loadingScene.progress >= 0.9f)
                {
                    loadingScene.allowSceneActivation = true;
                }

                await Task.Yield();
            }

            loadingScreen.SetActive(false);
        }
    }
}