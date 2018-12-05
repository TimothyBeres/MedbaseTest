using System.Linq;

namespace Open.Infra.Process
{
    public class DosageDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Dosages.Any()) return;
            c.SaveChanges();
        }
    }
}