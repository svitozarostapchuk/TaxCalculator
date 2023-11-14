using Data.Entities;
using Data.ModelBuilderExtensions;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class TaxCalculatorContext : DbContext
    {
        public TaxCalculatorContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaxBand> TaxBands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}