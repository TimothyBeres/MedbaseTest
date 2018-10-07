using System;
using System.Globalization;
using Open.Data.Money;

namespace Open.Domain.Money
{
    public static class CurrencyObjectFactory
    {
        public static CurrencyObject Create(string currencyId, string currencyName, string currencySymbol, DateTime? validFrom = null,
            DateTime? validTo = null)
        {
            var o = new CurrencyDbRecord
            {
                Code = currencySymbol,
                Name = currencyName,
                ID = currencyId,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new CurrencyObject(o);
        }

        public static CurrencyObject Create(RegionInfo r)
        {
            var currency = r?.CurrencyEnglishName;
            var id = r?.ISOCurrencySymbol;
            var currencySymbol = r?.CurrencySymbol;
            return Create(id, currency, currencySymbol);
        }
    }
}