using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sentry1.Models;

namespace Sentry1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //CreatePortfoliosTable(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        //public DbSet<PortfolioDbRecord> Portfolios { get; set; }
        //public static void CreatePortfoliosTable(ModelBuilder b)
        //{
        //    const string table = "Portfolios";
        //    createPrimaryKey<PortfolioDbRecord>(b, table, a => new { a.MedicineID, a.UserID });
        //    createForeignKey<PortfolioDbRecord, ApplicationUser>(b, table, x => x.UserID, x => x.User);
        //    createForeignKey<PortfolioDbRecord, MedicineDbRecord>(b, table, x => x.MedicineID, x => x.Medicine);
        //}
        //internal static void createPrimaryKey<TEntity>(
        //    ModelBuilder b,
        //    string tableName,
        //    Expression<Func<TEntity, object>> primaryKey)
        //    where TEntity : class
        //{
        //    b.Entity<TEntity>()
        //        .ToTable(tableName)
        //        .HasKey(primaryKey);
        //}

        //internal static void createForeignKey<TEntity, TRelatedEntity>(
        //    ModelBuilder b,
        //    string tableName,
        //    Expression<Func<TEntity, object>> foreignKey,
        //    Expression<Func<TEntity, TRelatedEntity>> getRelatedEntity)
        //    where TEntity : class where TRelatedEntity : class
        //{
        //    b.Entity<TEntity>()
        //        .ToTable(tableName)
        //        .HasOne(getRelatedEntity)
        //        .WithMany()
        //        .HasForeignKey(foreignKey)
        //        .OnDelete(DeleteBehavior.Restrict);
        //}
    }
}
