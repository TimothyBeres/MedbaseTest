using System.Collections.Generic;
using System.Linq;
using Open.Core;
using Open.Domain.Money;

namespace Open.Facade.Money
{
    public class CurrencyViewModelsList : PaginatedList<CurrencyViewModel>
    {
        public CurrencyViewModelsList(IPaginatedList<CurrencyObject> l, string sortOrder = null)
        {
            if (l is null) return;
            PageIndex = l.PageIndex;
            TotalPages = l.TotalPages;
            var currencies = new List<CurrencyViewModel>();
            IOrderedEnumerable<CurrencyViewModel> ordered;
            foreach (var e in l)
            {
                currencies.Add(CurrencyViewModelFactory.Create(e));
            }

            switch (sortOrder)
            {
                case "currency_desc":
                    ordered = currencies.OrderByDescending(s => s.Name);
                    break;
                case "alpha3":
                    ordered = currencies.OrderBy(s => s.Alpha3Code);
                    break;
                case "alpha3_desc":
                    ordered = currencies.OrderByDescending(s => s.Alpha3Code);
                    break;
                case "symbol":
                    ordered = currencies.OrderBy(s => s.CurrencySymbol);
                    break;
                case "symbol_desc":
                    ordered = currencies.OrderByDescending(s => s.CurrencySymbol);
                    break;
                case "validFrom":
                    ordered = currencies.OrderBy(s => s.ValidFrom);
                    break;
                case "validFrom_desc":
                    ordered = currencies.OrderByDescending(s => s.ValidFrom);
                    break;
                case "validTo":
                    ordered = currencies.OrderBy(s => s.ValidTo);
                    break;
                case "validTo_desc":
                    ordered = currencies.OrderByDescending(s => s.ValidTo);
                    break;
                default:
                    ordered = currencies.OrderBy(s => s.Name);
                    break;
            }
            AddRange(ordered);
        }
    }
}