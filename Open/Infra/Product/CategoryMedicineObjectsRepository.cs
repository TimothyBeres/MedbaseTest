using Microsoft.EntityFrameworkCore;
using Open.Data.Product;
using Open.Domain.Product;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Open.Infra.Product
{
    public class CategoryMedicineObjectsRepository : ICategoryMedicineObjectsRepository
    {
        private readonly DbSet<CategoryMedicineDbRecord> dbSet;
        private readonly DbContext db;
        public CategoryMedicineObjectsRepository(SentryDbContext c)
        {
            db = c;
            dbSet = c?.CategoryMedicines;
        }
        public Task<CategoryMedicineObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }

        public async Task FindObjects(CategoryObject e, MedicineObject m)
        {
            var e_id = e.DbRecord?.ID ?? string.Empty;
            var m_id = m.DbRecord?.ID ?? string.Empty;
        }
        public async Task AddObject(CategoryMedicineObject o)
        {
            var r = o.DbRecord;
            r.Category = null;
            r.Medicine = null;
            dbSet.Add(r);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(CategoryMedicineObject o)
        {
            var r = o.DbRecord;
            r.Category = null;
            r.Medicine = null;
            dbSet.Update(r);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(CategoryMedicineObject o)
        {
            var r = o.DbRecord;
            r.Category = null;
            r.Medicine = null;
            dbSet.Remove(r);
            await db.SaveChangesAsync();
        }
        public async Task LoadMedicines(CategoryObject category)
        {
            if (category is null) return;
            var id = category.DbRecord?.ID ?? string.Empty;
            var medicines = await dbSet.Include(x => x.Medicine).Where(x => x.CategoryID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in medicines)
                category.MedicineWithCategory(new MedicineObject(c.Medicine));
        }
        public async Task LoadCategories(MedicineObject medicine)
        {
            if (medicine is null) return;
            var id = medicine.DbRecord?.ID ?? string.Empty;
            var effects = await dbSet.Include(x => x.Category).Where(x => x.MedicineID == id)
                .AsNoTracking().ToListAsync();
            //foreach (var c in effects)
            //    medicine.EffectsInMedicine(new EffectObject(c.Effect));
        }
        public async Task<CategoryMedicineObject> GetObject(string category, string medicine)
        {
            var o = await dbSet.FirstOrDefaultAsync(
                x => x.CategoryID == category && x.MedicineID == medicine);
            return new CategoryMedicineObject(o);
        }
    }
}