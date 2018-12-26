using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Text;

namespace Open.Infra.Representor
{
    public static class MedicineRepresentorsDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.MedicineRepresentors.Any()) return;

            c.SaveChanges();
            

        }
    }
}
