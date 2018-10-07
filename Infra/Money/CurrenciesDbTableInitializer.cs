using System.Collections.Generic;
using System.Linq;
using Open.Aids;
using Open.Domain.Money;

namespace Open.Infra.Money
{
    public static class CurrenciesDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Currencies.Any()) return;
            var regions = SystemRegionInfo.GetRegionsList();
            var l = new List<string>();
            foreach (var r in regions)
            {
                if (!SystemRegionInfo.IsCurrency(r)) continue;
                if (l.Contains(r.ISOCurrencySymbol)) continue;
                var e = CurrencyObjectFactory.Create(r);
                c.Currencies.Add(e.DbRecord);
                l.Add(r.ISOCurrencySymbol);
            }

            c.SaveChanges();
        }
    }
}