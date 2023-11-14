using Data.Entities;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Data.Enums;

namespace Data.ModelBuilderExtensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxBand>().HasData(
                new TaxBand
                {
                    Id = 1,
                    Category = TaxBandCategory.A,
                    BottomLimit = 1,
                    UpperLimit = 5000,
                    Rate = 0,
                },
                new TaxBand
                {
                    Id = 2,
                    Category = TaxBandCategory.B,
                    BottomLimit = 5001,
                    UpperLimit = 20000,
                    Rate = 20,
                },
                new TaxBand
                {
                    Id = 3,
                    Category = TaxBandCategory.C,
                    BottomLimit = 20001,
                    UpperLimit = int.MaxValue,
                    Rate = 40,
                }
            );
        }
    }
}
