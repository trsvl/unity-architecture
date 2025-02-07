using UnityEngine;

namespace _Project.Scripts.MainMenu.Screens
{
    public abstract class MainMenuScreen : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        public virtual void Load()
        {
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = Camera.main;
        }

        public abstract void Enable();
        public abstract void Disable();
    }
}