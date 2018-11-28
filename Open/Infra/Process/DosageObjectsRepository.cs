using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
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
    }
}