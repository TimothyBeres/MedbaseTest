using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Text;
using Open.Data.Representor;

namespace Open.Infra.Representor
{
    public static class MedicineRepresentorsDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.MedicineRepresentors.Any()) return;
            foreach (var a in c.Medicines)
            {
                foreach (var p in c.Representors)
                {
                    var x = new MedicineRepresentorDbRecord()
                    {
                        RepresentorID = p.ID,
                        MedicineID = a.ID,
                    };
                    c.MedicineRepresentors.Add(x);
                }

            }
            c.SaveChanges();
            

        }

        
    }
}
