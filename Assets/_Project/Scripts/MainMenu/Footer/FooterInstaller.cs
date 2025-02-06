using System;
using _Project.Scripts.GameSystemLogic;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.MainMenu.Footer
{
    public class FooterInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameObject[] _footerButtons;


        public void Register(Container container)
        {
            var footerController = new FooterController();
            var stateObserver = container.GetService<IMainMenuStateObserver>();

            MainMenuState[] states =
            {
                MainMenuState.ShopScreen,
                MainMenuState.BattleScreen,
                MainMenuState.CardsScreen
            };

            Action[] actions =
            {
                stateObserver.ShopScreen,
                stateObserver.BattleScreen,
                stateObserver.CardsScreen
            };

            for (int i = 0; i < _footerButtons.Length; i++)
            {
                int index = i;

                var image = _footerButtons[i].GetComponent<Image>();
                var imageRect = image.GetComponent<RectTransform>();
                var button = _footerButtons[i].GetComponent<Button>();

                var footerButton = new FooterButton(image, imageRect, states[i]);

                footerController.SetActiveButton(footerButton, stateObserver.MainMenuState);

                button.onClick.AddListener(() => footerController.OnClick(footerButton, actions[index]));
            }
        }
    }
}