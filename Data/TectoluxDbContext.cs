

using Microsoft.EntityFrameworkCore;
using TectoluxConfigurator.Data.Entities;

namespace TectoluxAPI.Data
{
    public class TectoluxDbContext : DbContext
    {
        public TectoluxDbContext(DbContextOptions<TectoluxDbContext> options)
            : base(options)
        {
        }

        public DbSet<Option> Options { get; set; }
        public DbSet<GlassOption> GlassOptions { get; set; }
        public DbSet<BlindsOption> BlindsOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var product = modelBuilder.Entity<Option>();

            product.Property(x => x.Id).IsRequired();
            product.Property(x => x.Description);
            product.Property(x => x.SortOrder).IsRequired();
            product.Property(x => x.Price).IsRequired();
            product.Property(x => x.IsArchived).HasDefaultValue(false);

        }

    }
}
