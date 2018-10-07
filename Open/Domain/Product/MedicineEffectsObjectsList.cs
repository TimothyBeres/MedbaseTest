using System.Collections.Generic;
using Open.Core;
using Open.Data.Effect;

namespace Open.Domain.Product
{
    public class MedicineEffectsObjectsList : PaginatedList<MedicineEffectsObject>
    {
        public MedicineEffectsObjectsList(IEnumerable<MedicineEffectsDbRecord> items,
            RepositoryPage page) :
            base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new MedicineEffectsObject(dbRecord));
            }
        }
    }
}