using System.Collections.Generic;
using Open.Core;
using Open.Data.Process;

namespace Open.Domain.Process
{
    public class SchemeObjectsList : PaginatedList<SchemeObject>
    {
        public SchemeObjectsList(IEnumerable<SchemeDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbrecord in items)
            {
                Add(new SchemeObject(dbrecord));
            }
        }
    }
}