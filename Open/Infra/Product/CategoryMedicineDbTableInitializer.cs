using System.Linq;

namespace Open.Infra.Product
{
    public static class CategoryMedicineDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.CategoryMedicines.Any()) return;

            c.SaveChanges();

        }
    }
}