using _Project.Scripts.GameSystemLogic;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.MainMenu.Footer
{
    public class FooterInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameObject[] footerButtons;


        public void Register(Container container)
        {
            var footerController = new FooterController();

            for (int i = 0; i < footerButtons.Length; i++)
            {
                var image = footerButtons[i].GetComponent<Image>();
                var imageRect = image.GetComponent<RectTransform>();
                var footerButton = new FooterButton(image, imageRect);

                if (i == 2) footerController.OnClick(footerButton);

                var button = footerButtons[i].GetComponent<Button>();
                button.onClick.AddListener(() => footerController.OnClick(footerButton));
            }
        }
    }
}