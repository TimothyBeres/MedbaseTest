using Open.Core;
using Open.Domain.Product;
using System.Collections.Generic;
using System.Linq;

namespace Open.Facade.Product
{
    public class CategoryViewModelsList : PaginatedList<CategoryViewModel>
    {
        public CategoryViewModelsList(IPaginatedList<CategoryObject> list, string sortOrder = null)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            var catalogues = new List<CategoryViewModel>();
            IOrderedEnumerable<CategoryViewModel> ordered;
            foreach (var e in list)
            {
                catalogues.Add(CategoryViewModelFactory.Create(e));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ordered = catalogues.OrderByDescending(s => s.CategoryName);
                    break;
                case "validFrom":
                    ordered = catalogues.OrderBy(s => s.ValidFrom);
                    break;
                case "validFrom_desc":
                    ordered = catalogues.OrderByDescending(s => s.ValidFrom);
                    break;
                case "validTo":
                    ordered = catalogues.OrderBy(s => s.ValidTo);
                    break;
                case "validTo_desc":
                    ordered = catalogues.OrderByDescending(s => s.ValidTo);
                    break;
                default:
                    ordered = catalogues.OrderBy(s => s.CategoryName);
                    break;
            }

            AddRange(ordered);
        }
    }
}