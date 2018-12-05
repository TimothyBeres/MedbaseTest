using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Open.Core;
using Open.Data.Person;
using Open.Data.Process;
using Open.Domain.Process;

namespace Open.Infra.Process
{
    public class DosageObjectsRepository : ObjectsRepository<DosageObject, DosageDbRecord>, IDosageObjectsRepository
    {
        private readonly DbSet<DosageDbRecord> dbSet;

        public DosageObjectsRepository(SentryDbContext c) : base(c?.Dosages, c)
        {
            dbSet = c.Dosages;
        }

        protected internal override DosageObject createObject(DosageDbRecord r)
        {
            return new DosageObject(r);
        }

        protected internal override PaginatedList<DosageObject> createList(
            List<DosageDbRecord> l, RepositoryPage p)
        {
            return new DosageObjectsList(l, p);
        }
        public async Task<List<DosageObject>> GetAllDosages(string personId)
        {
            var allDosages = await GetObjectsList();
            var dosages = allDosages.Where(x => x.DbRecord.PersonID == personId);
            var list = new List<DosageDbRecord>();
            foreach (var i in dosages)
            {
                list.Add(i.DbRecord);
            }

            return createList(list, new RepositoryPage(list.Count));

        }
    }
}