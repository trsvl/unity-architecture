using _Project.Scripts.Utils.Currency;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class CurrencyDataController
    {
        public ulong GoldCurrency { get; private set; }
        public ulong DiamondCurrency { get; private set; }

        private readonly CurrencyConverter _currencyConverter = new();


        public void LoadData()
        {
            var goldCurrencyValue = PlayerPrefs.GetString("GoldCurrency", "0");
            GoldCurrency = ParseData(goldCurrencyValue);

            var diamondValue = PlayerPrefs.GetString("DiamondCurrency", "0");
            DiamondCurrency = ParseData(diamondValue);
        }
        
        public void SetCurrency(TextMeshProUGUI textMeshProUGUI, ulong currency)
        {
            textMeshProUGUI.SetText(_currencyConverter.Do(currency));
        }

        public void AddGoldCurrency(TextMeshProUGUI textMeshProUGUI, ulong goldCurrency)
        {
            GoldCurrency += goldCurrency;
            textMeshProUGUI.SetText(_currencyConverter.Do(goldCurrency));
        }

        public void AddDiamondCurrency(TextMeshProUGUI textMeshProUGUI, ulong diamondCurrency)
        {
            DiamondCurrency += diamondCurrency;
            textMeshProUGUI.SetText(_currencyConverter.Do(diamondCurrency));
        }

        public void RemoveGoldCurrency(TextMeshProUGUI textMeshProUGUI, ulong goldCurrency)
        {
            GoldCurrency -= goldCurrency;
            textMeshProUGUI.SetText(_currencyConverter.Do(goldCurrency));
        }

        public void RemoveDiamondCurrency(TextMeshProUGUI textMeshProUGUI, ulong diamondCurrency)
        {
            DiamondCurrency -= diamondCurrency;
            textMeshProUGUI.SetText(_currencyConverter.Do(diamondCurrency));
        }

        private ulong ParseData(string data)
        {
            return ulong.TryParse(data, out var result) ? result : 0;
        }
    }
}