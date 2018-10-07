using System.Collections.Generic;
using Open.Core;
using Open.Data.Effect;
using Open.Domain.Product;

namespace Open.Infra.Product
{
    public class EffectObjectsRepository : ObjectsRepository<EffectObject, EffectDbRecord>,
        IEffectObjectsRepository
    {
        public EffectObjectsRepository(SentryDbContext c) : base(c?.Effects, c) { }

        protected internal override EffectObject createObject(EffectDbRecord r)
        {
            return new EffectObject(r);
        }

        protected internal override PaginatedList<EffectObject> createList(
            List<EffectDbRecord> l, RepositoryPage p)
        {
            return new EffectObjectsList(l, p);
        }
    }
}