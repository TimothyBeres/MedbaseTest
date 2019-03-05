using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Data.Product;
using Open.Domain.Product;
using Open.Domain.User;

namespace Open.Infra.Product
{
    public class PortfolioObjectsRepository : IPortfolioObjectsRepository
    {
        private readonly DbSet<PortfolioDbRecord> dbSet;
        private readonly DbContext db;
        public PortfolioObjectsRepository(SentryDbContext c)
        {
            db = c;
            dbSet = c?.Portfolios;
        }
        public Task<PortfolioObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }
        public async Task AddObject(PortfolioObject o)
        {
            var r = o.DbRecord;
            r.Medicine = null;
            dbSet.Add(r);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(PortfolioObject o)
        {
            var r = o.DbRecord;
            r.Medicine = null;
            dbSet.Update(r);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(PortfolioObject o)
        {
            var r = o.DbRecord;
            r.Medicine = null;
            dbSet.Remove(r);
            await db.SaveChangesAsync();
        }
        public async Task LoadMedicines(IIdentityUser user)
        {

            //if (effect is null) return;
            //var id = effect.DbRecord?.ID ?? string.Empty;
            //var medicines = await dbSet.Include(x => x.Medicine).Where(x => x.UserID == id)
            //    .AsNoTracking().ToListAsync();
            //foreach (var c in medicines)
            //    effect.UsedInMedicine(new MedicineObject(c.Medicine));
        }
    }
}
