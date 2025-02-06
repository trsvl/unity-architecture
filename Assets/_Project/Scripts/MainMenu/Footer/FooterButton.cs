using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.MainMenu.Footer
{
    public class FooterButton
    {
        public Image Image { get; private set; }
        public RectTransform RectTransform { get; private set; }
        public MainMenuState State { get; private set; }


        public FooterButton(Image image, RectTransform rectTransform, MainMenuState state)
        {
            Image = image;
            RectTransform = rectTransform;
            State = state;
        }
    }
}