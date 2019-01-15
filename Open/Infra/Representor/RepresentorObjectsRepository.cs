using System;
using System.Collections.Generic;
using System.Text;
using Open.Core;
using Open.Data.Product;
using Open.Data.Representor;
using Open.Domain.Product;
using Open.Domain.Representor;

namespace Open.Infra.Representor
{
    public class RepresentorObjectsRepository : ObjectsRepository<RepresentorObject, RepresentorDbRecord>,
        IRepresentorObjectsRepository
    {
        public RepresentorObjectsRepository(SentryDbContext c) : base(c?.Representors, c) { }

        protected internal override RepresentorObject createObject(RepresentorDbRecord r)
        {
            return new RepresentorObject(r);
        }

        protected internal override PaginatedList<RepresentorObject> createList(
            List<RepresentorDbRecord> l, RepositoryPage p)
        {
            return new RepresentorObjectsList(l, p);
        }
    }
}
