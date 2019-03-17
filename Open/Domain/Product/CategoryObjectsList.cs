using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Product;

namespace Open.Domain.Product
{
    public class CategoryObjectsList : PaginatedList<CategoryObject>
    {
        public CategoryObjectsList(IEnumerable<CategoryDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new CategoryObject(dbRecord));
            }
        }
    }
}
