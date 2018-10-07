using System.Collections;
using System.Collections.Generic;
using Open.Core;
using Open.Data.Effect;

namespace Open.Domain.Product
{
    public class EffectObjectsList : PaginatedList<EffectObject>
    {
        public EffectObjectsList(IEnumerable<EffectDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new EffectObject(dbRecord));
            }
        }
    }
}