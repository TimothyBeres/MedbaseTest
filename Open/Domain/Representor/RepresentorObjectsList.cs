using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Representor;

namespace Open.Domain.Representor
{
    public class RepresentorObjectsList : PaginatedList<RepresentorObject>
    {
        public RepresentorObjectsList(IEnumerable<RepresentorDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new RepresentorObject(dbRecord));
            }
        }
    }
}
