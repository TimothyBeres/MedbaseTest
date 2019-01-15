using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Open.Data.Person;
using Open.Domain.Person;
using Open.Domain.Product;

namespace Open.Infra.Person
{
    public class PersonMedicineObjectsRepository : IPersonMedicineObjectsRepository
    {
        private readonly DbSet<PersonMedicineDbRecord> dbSet;
        private readonly DbContext db;

        public PersonMedicineObjectsRepository(SentryDbContext c)
        {
            db = c;
            dbSet = c?.PersonMedicines;
        }

        public Task<PersonMedicineObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }

        public async Task FindObjects(PersonObject p, MedicineObject m)
        {
            var p_id = p.DbRecord?.ID ?? string.Empty;
            var m_id = m.DbRecord?.ID ?? string.Empty;
        }

        public async Task AddObject(PersonMedicineObject o)
        {
            var r = o.DbRecord;
            r.Person = null;
            r.Medicine = null;
            dbSet.Add(r);
            await db.SaveChangesAsync();
        }

        public async Task UpdateObject(PersonMedicineObject o)
        {
            var r = o.DbRecord;
            r.Person = null;
            r.Medicine = null;
            dbSet.Update(r);
            await db.SaveChangesAsync();
        }

        public async Task DeleteObject(PersonMedicineObject o)
        {
            var r = o.DbRecord;
            r.Person = null;
            r.Medicine = null;
            dbSet.Remove(r);
            await db.SaveChangesAsync();
        }

        public async Task LoadMedicines(PersonObject person)
        {
            if (person is null) return;
            var id = person.DbRecord?.ID ?? string.Empty;
            var medicines = await dbSet.Include(x => x.Medicine).Where(x => x.PersonID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in medicines)
                person.MedicineInUse(new MedicineObject(c.Medicine));
        }

        /*public async Task LoadPersons(MedicineObject medicine)
        {
            if (medicine is null) return;
            var id = medicine.DbRecord?.ID ?? string.Empty;
            var persons = await dbSet.Include(x => x.Person).Where(x => x.MedicineID == id)
                .AsNoTracking().ToListAsync();
            //foreach (var c in persons)
            //medicine.EffectsInMedicine(new PersonObject(c.Person));
        }*/

        public async Task<PersonMedicineObject> GetObject(string medicineId, string personId)
        {
            var o = await dbSet.FirstOrDefaultAsync(
                x => x.PersonID == personId && x.MedicineID == medicineId);
            return new PersonMedicineObject(o);
        }

        public async Task<bool> CanUseMedicine(string medicine, string person)
        {
            var o = await dbSet.FirstOrDefaultAsync(x => x.PersonID == person && x.MedicineID == medicine);
            if (o.Suitability == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}