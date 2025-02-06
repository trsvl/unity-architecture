#nullable enable
using System;
using System.Collections.Generic;

namespace _Project.Scripts.Utils.Currency
{
    public class CurrencyConverter
    {
        private readonly Dictionary<int, string> abbreviations = new()
        {
            { 3, "k" },
            { 6, "m" },
            { 9, "b" },
            { 12, "t" },
            { 15, "q" },
            { 18, "Q" },
        };


        public string Do(ulong currency)
        {
            if (ulong.MaxValue <= currency) return "max";

            var roundedExponent = (int)Math.Floor(Math.Log10(currency)) + 1;

            int exponent = roundedExponent % 3 == 0 ? roundedExponent : roundedExponent - roundedExponent % 3;

            if (!abbreviations.TryGetValue(exponent, out string? abbreviation)) return currency.ToString();

            string currencyString = currency.ToString();

            int integerPartIndex = roundedExponent % 3 == 0 ? 1 : roundedExponent % 3 + 1;
            var integerPart = currencyString[..integerPartIndex];

            var decimalPartIndex = 3 - integerPartIndex;
            string decimalPart = decimalPartIndex == 0
                ? ""
                : "." + currencyString.Substring(integerPartIndex, decimalPartIndex);

            return $"{integerPart}{decimalPart}{abbreviation}";
        }
    }
}