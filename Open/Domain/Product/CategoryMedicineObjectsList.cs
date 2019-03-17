using Open.Core;
using Open.Data.Product;
using System.Collections.Generic;

namespace Open.Domain.Product
{
    public class CategoryMedicineObjectsList : PaginatedList<CategoryMedicineObject>
    {
        public CategoryMedicineObjectsList(IEnumerable<CategoryMedicineDbRecord> items,
            RepositoryPage page) :
            base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new CategoryMedicineObject(dbRecord));
            }
        }
    }
}