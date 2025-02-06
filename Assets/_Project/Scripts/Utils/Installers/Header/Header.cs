using TMPro;
using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class Header : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldCurrencyText;
        [SerializeField] private TextMeshProUGUI _currentScreenText;
        [SerializeField] private TextMeshProUGUI _diamondCurrencyText;


        public void Init()
        {
            var currencyController = ProjectData.Instance.CurrencyDataController;
            currencyController.SetCurrency(_goldCurrencyText, currencyController.GoldCurrency);
            currencyController.SetCurrency(_diamondCurrencyText, currencyController.DiamondCurrency);
        }
    }
}