using System.Collections.Generic;
using System.Linq;
using Open.Core;
using Open.Domain.Product;

namespace Open.Facade.Product
{
    public class EffectViewModelsList : PaginatedList<EffectViewModel>
    {
        public EffectViewModelsList(IPaginatedList<EffectObject> list, string sortOrder = null)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            var products = new List<EffectViewModel>();
            IOrderedEnumerable<EffectViewModel> ordered;
            foreach (var e in list)
            {
                products.Add(EffectViewModelFactory.Create(e));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ordered = products.OrderByDescending(s => s.Name);
                    break;
                case "validFrom":
                    ordered = products.OrderBy(s => s.ValidFrom);
                    break;
                case "validFrom_desc":
                    ordered = products.OrderByDescending(s => s.ValidFrom);
                    break;
                case "validTo":
                    ordered = products.OrderBy(s => s.ValidTo);
                    break;
                case "validTo_desc":
                    ordered = products.OrderByDescending(s => s.ValidTo);
                    break;
                default:
                    ordered = products.OrderBy(s => s.Name);
                    break;
            }
            AddRange(ordered);
        }
    }
}