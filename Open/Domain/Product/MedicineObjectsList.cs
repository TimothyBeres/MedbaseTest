using System.Collections;
using System.Collections.Generic;
using Open.Core;
using Open.Data.Effect;

namespace Open.Domain.Product
{
    public class MedicineObjectsList : PaginatedList<MedicineObject>
    {
        public MedicineObjectsList(IEnumerable<MedicineDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new MedicineObject(dbRecord));
            }
        }
    }
}