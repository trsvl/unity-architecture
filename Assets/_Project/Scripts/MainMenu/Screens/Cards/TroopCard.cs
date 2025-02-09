using _Project.Scripts.Utils.Installers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.MainMenu.Screens
{
    public class TroopCard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _troopImage;
        [SerializeField] private Button _troopButton;
        [SerializeField] private Button _upgradeButton;


        public void Init(int level, ulong price, Sprite sprite, bool isEnabled)
        {
            _levelText.SetText(level.ToString());
            ProjectData.Instance.CurrencyDataController.SetCurrency(_priceText, price);
            _troopImage.sprite = sprite;

            if (isEnabled) return;

            _troopButton.interactable = false;
            _upgradeButton.interactable = false;
        }
    }
}