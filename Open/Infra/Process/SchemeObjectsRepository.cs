using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Process;
using Open.Domain.Process;

namespace Open.Infra.Process
{
    public class SchemeObjectsRepository : ObjectsRepository<SchemeObject, SchemeDbRecord>, ISchemeObjectsRepository
    {
        private readonly SentryDbContext db;
        private readonly DbSet<SchemeDbRecord> dbSet;

        public SchemeObjectsRepository(SentryDbContext c) : base(c?.Schemes, c)
        {
            db = c;
            dbSet = c?.Schemes;
        }

        protected internal override SchemeObject createObject(SchemeDbRecord r)
        {
            return new SchemeObject(r);
        }
        protected internal override PaginatedList<SchemeObject> createList(
            List<SchemeDbRecord> l, RepositoryPage p)
        {
            return new SchemeObjectsList(l, p);
        }

        public async Task LoadSchemes(DosageObject dosage)
        {
            if (dosage is null) return;
            PageSize = 50;
            var allSchemes = await GetObjectsList();
            var correspondingOptions = GetSchemesByDosageID(dosage, allSchemes);
            foreach (var i in correspondingOptions)
                dosage.SchemeInUse(new SchemeObject(i.DbRecord));
        }
        public IEnumerable<SchemeObject> GetSchemesByDosageID(DosageObject dosage, List<SchemeObject> allOptions)
        {
            var correspondingOptions = allOptions.Where(x => x.DbRecord.DosageId == dosage.DbRecord.ID);
            return correspondingOptions;
        }
    }
}