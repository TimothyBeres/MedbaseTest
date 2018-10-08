using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Data.Product;
using Open.Domain.Location;
using Open.Domain.Money;
using Open.Domain.Product;

namespace Open.Infra.Product
{
    public class MedicineEffectsObjectsRepository : IMedicineEffectsObjectsRepository
    {
        private readonly DbSet<MedicineEffectsDbRecord> dbSet;
        private readonly DbContext db;
        public MedicineEffectsObjectsRepository(SentryDbContext c)
        {
            db = c;
            dbSet = c?.MedicineEffects;
        }
        public Task<MedicineEffectsObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }

        public async Task FindObjects(EffectObject e, MedicineObject m)
        {
            var e_id = e.DbRecord?.ID ?? string.Empty;
            var m_id = m.DbRecord?.ID ?? string.Empty;
        }
        public async Task AddObject(MedicineEffectsObject o)
        {
            var r = o.DbRecord;
            r.Effect = null;
            r.Medicine = null;
            dbSet.Add(r);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(MedicineEffectsObject o)
        {
            var r = o.DbRecord;
            r.Effect = null;
            r.Medicine = null;
            dbSet.Update(r);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(MedicineEffectsObject o)
        {
            var r = o.DbRecord;
            r.Effect = null;
            r.Medicine = null;
            dbSet.Remove(r);
            await db.SaveChangesAsync();
        }
        public async Task LoadMedicines(EffectObject effect)
        {
            if (effect is null) return;
            var id = effect.DbRecord?.ID ?? string.Empty;
            var medicines = await dbSet.Include(x => x.Medicine).Where(x => x.EffectID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in medicines)
                effect.UsedInMedicines(new MedicineObject(c.Medicine));
        }
        public async Task LoadEffects(MedicineObject medicine)
        {
            if (medicine is null) return;
            var id = medicine.DbRecord?.ID ?? string.Empty;
            var effects = await dbSet.Include(x => x.Effect).Where(x => x.MedicineID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in effects)
                medicine.EffectsInMedicine(new EffectObject(c.Effect));
        }
        public async Task<MedicineEffectsObject> GetObject(string effect, string medicine)
        {
            var o = await dbSet.FirstOrDefaultAsync(
                x => x.EffectID == effect && x.MedicineID == medicine);
            return new MedicineEffectsObject(o);
        }
    }
}