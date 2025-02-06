using _Project.Scripts.Utils.Currency;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Utils.Installers
{
    public class CurrencyDataController
    {
        private TextMeshProUGUI _goldCurrencyText = null;
        private TextMeshProUGUI _diamondCurrencyText = null;

        public ulong GoldCurrency
        {
            get => _goldCurrency;
            private set
            {
                SetCurrency(_goldCurrencyText, value);
                _goldCurrency = value;
            }
        }

        public ulong DiamondCurrency
        {
            get => _diamondCurrency;
            private set
            {
                SetCurrency(_diamondCurrencyText, value);
                _diamondCurrency = value;
            }
        }

        private readonly CurrencyConverter _currencyConverter = new();
        private const string GOLD_CURRENCY = "GoldCurrency";
        private const string DIAMOND_CURRENCY = "DiamondCurrency";
        private ulong _goldCurrency;
        private ulong _diamondCurrency;


        public void LoadData()
        {
            var goldCurrencyValue = PlayerPrefs.GetString(GOLD_CURRENCY, "0");
            GoldCurrency = ParseData(goldCurrencyValue);

            var diamondValue = PlayerPrefs.GetString(DIAMOND_CURRENCY, "0");
            DiamondCurrency = ParseData(diamondValue);
        }

        public void SetCurrency(TextMeshProUGUI textMeshProUGUI, ulong currency)
        {
            textMeshProUGUI?.SetText(_currencyConverter.Do(currency));
        }

        public void BindGoldCurrencyText(TextMeshProUGUI textMeshProUGUI)
        {
            _goldCurrencyText = textMeshProUGUI;
            SetCurrency(_goldCurrencyText, GoldCurrency);
        }

        public void BindDiamondCurrencyText(TextMeshProUGUI textMeshProUGUI)
        {
            _diamondCurrencyText = textMeshProUGUI;
            SetCurrency(_diamondCurrencyText, DiamondCurrency);
        }

        public void AddGoldCurrency(ulong goldCurrency)
        {
            if (GoldCurrency > ulong.MaxValue - goldCurrency)
            {
                GoldCurrency = ulong.MaxValue;
            }
            else GoldCurrency += goldCurrency;

            PlayerPrefs.SetString(GOLD_CURRENCY, GoldCurrency.ToString());
        }

        public void AddDiamondCurrency(ulong diamondCurrency)
        {
            if (DiamondCurrency > ulong.MaxValue - diamondCurrency)
            {
                DiamondCurrency = ulong.MaxValue;
            }
            else DiamondCurrency += diamondCurrency;

            PlayerPrefs.SetString(DIAMOND_CURRENCY, DiamondCurrency.ToString());
        }

        public void RemoveGoldCurrency(ulong goldCurrency)
        {
            if (GoldCurrency < ulong.MinValue + goldCurrency)
            {
                Debug.LogError("Unacceptable Action");
                return;
            }
            else GoldCurrency -= goldCurrency;

            PlayerPrefs.SetString(GOLD_CURRENCY, GoldCurrency.ToString());
        }

        public void RemoveDiamondCurrency(ulong diamondCurrency)
        {
            if (DiamondCurrency < ulong.MinValue + diamondCurrency)
            {
                Debug.LogError("Unacceptable Action");
                return;
            }
            else DiamondCurrency -= diamondCurrency;

            PlayerPrefs.SetString(DIAMOND_CURRENCY, GoldCurrency.ToString());
        }

        private ulong ParseData(string data)
        {
            return ulong.TryParse(data, out var result) ? result : 0;
        }
    }
}