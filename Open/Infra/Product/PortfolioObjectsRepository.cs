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
        private readonly DbSet<MedicineDbRecord> dbSetMedicines;
        public PortfolioObjectsRepository(SentryDbContext c)
        {
            db = c;
            dbSet = c?.Portfolios;
            dbSetMedicines = c?.Medicines;
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

        public async Task<PortfolioObject> GetObject(string medicineId, string userId)
        {
            var o = await dbSet.FirstOrDefaultAsync(
                x => x.MedicineID == medicineId && x.UserID == userId);
            return new PortfolioObject(o);
        }
        public async Task<List<MedicineObject>> GetMedicines(string userId)
        {
            if (userId is null)return null;
            var portfolioObjects = await dbSet.Include(x => x.Medicine).Where(x => x.UserID == userId)
                .AsNoTracking().ToListAsync();
            List<MedicineObject> medicines = new List<MedicineObject>();
            foreach (var m in portfolioObjects)
            {
                var mdb = await dbSetMedicines.FirstOrDefaultAsync(x => x.ID == m.MedicineID);
                medicines.Add(MedicineObjectFactory.Create(mdb.ID, mdb.Name, mdb.AtcCode, mdb.FormOfInjection, mdb.Strength,
                    mdb.Manufacturer, mdb.LegalStatus, mdb.Reimbursement, mdb.Spc, mdb.Pil, mdb.ValidFrom, mdb.ValidTo));
            }
            return medicines;
        }
    }
}
