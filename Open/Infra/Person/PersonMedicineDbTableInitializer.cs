using System.Linq;
using Open.Data.Person;

namespace Open.Infra.Person
{
    public static class PersonMedicineDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.PersonMedicines.Any()) return;

            c.SaveChanges();
            foreach (var a in c.Persons)
            {
                foreach (var p in c.Medicines)
                {
                    var x = new PersonMedicineDbRecord()
                    {
                        MedicineID = p.ID,
                        PersonID = a.ID
                    };
                    c.PersonMedicines.Add(x);
                }
            }

            c.SaveChanges();

        }
    }
}