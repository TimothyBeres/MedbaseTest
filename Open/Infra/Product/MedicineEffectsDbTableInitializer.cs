using System.Linq;
using Open.Aids;
using Open.Data.Product;

namespace Open.Infra.Product
{
    public static class MedicineEffectsDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.MedicineEffects.Any()) return;

            c.SaveChanges();
            /*foreach (var a in c.Medicines)
            {
                foreach (var p in c.Effects)
                {
                    var x = new MedicineEffectsDbRecord()
                    {
                        EffectID = p.ID,
                        MedicineID = a.ID,
                    };
                    c.MedicineEffects.Add(x);
                }

            }
            c.SaveChanges();*/

        }
    }
}