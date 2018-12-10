using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Product;
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
        public async Task<MedicineObject> GetMedicine(string name, string injection, string strength)
        {
            var allMeds = await GetObjectsList();
            var medicines = allMeds.Where(x => x.DbRecord.Name == name && x.DbRecord.FormOfInjection == injection && x.DbRecord.Strength == strength);
            var list = new List<MedicineDbRecord>();
            foreach (var i in medicines)
            {
                list.Add(i.DbRecord);
            }
            return createObject(list[0]);

        }
    }
}