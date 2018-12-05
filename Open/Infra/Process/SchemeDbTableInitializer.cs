using System.Linq;

namespace Open.Infra.Process
{
    public class SchemeDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Schemes.Any()) return;
            c.SaveChanges();
        }
    }
}