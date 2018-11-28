using System.Collections.Generic;
using Open.Core;
using Open.Data.Process;

namespace Open.Domain.Process
{
    public class DosageObjectsList : PaginatedList<DosageObject>
    {
        public DosageObjectsList(IEnumerable<DosageDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbrecord in items)
            {
                Add(new DosageObject(dbrecord));
            }
        }
    }
}