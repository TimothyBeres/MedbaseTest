using System.Linq;

namespace Open.Infra.Product
{
    public static class CategoriesDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Categories.Any()) return;
            //initEffects(c);
            c.SaveChanges();
        }
    }
}