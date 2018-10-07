using System.Collections.Generic;
using Open.Core;
using Open.Data.Effect;
using Open.Domain.Product;

namespace Open.Infra.Product
{
    public class MedicineObjectsRepository : ObjectsRepository<MedicineObject, MedicineDbRecord>,
        IMedicineObjectsRepository
    {
        public MedicineObjectsRepository(SentryDbContext c) : base(c?.Medicines, c) { }

        protected internal override MedicineObject createObject(MedicineDbRecord r)
        {
            return new MedicineObject(r);
        }

        protected internal override PaginatedList<MedicineObject> createList(
            List<MedicineDbRecord> l, RepositoryPage p)
        {
            return new MedicineObjectsList(l, p);
        }
    }
}