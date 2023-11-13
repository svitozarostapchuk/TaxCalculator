using Data.Entities;
using Data.ModelBuilderExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Contexts
{
    public class TaxCalculatorContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public TaxCalculatorContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("ConStr"));
        }

        public DbSet<TaxBand> TaxBands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}