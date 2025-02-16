using _Project.Scripts.Gameplay.Troops.Base;
using _Project.Scripts.Utils.Installers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.MainMenu.Screens
{
    public class TroopCard : MonoBehaviour
    {
        public TroopData TroopData { get; private set; }
        public bool IsSelected { get; private set; }

        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _troopImage;
        [SerializeField] private Button _troopButton;
        [SerializeField] private Button _upgradeButton;

        private CurrencyDataController _currencyDataController;

        public void Init(int level, ulong price, Sprite sprite, CurrencyDataController currencyDataController,
            TroopData troopData, bool isSelected, bool isEnabled)
        {
            TroopData = troopData;
            IsSelected = isSelected;
            
            _levelText.SetText(level.ToString());
            _currencyDataController.SetCurrency(_priceText, price);
            _troopImage.sprite = sprite;

            if (isSelected)
            {
                //
            }

            if (isEnabled) return;
            
            _troopButton.interactable = false;
            _upgradeButton.interactable = false;
        }
    }
}