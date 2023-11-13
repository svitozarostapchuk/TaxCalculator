using BusinessLogic.Models;
using Data.Entities;

namespace BusinessLogic.Services.Interfaces
{
    public interface ITaxBandService
    {
        public IQueryable<TaxBand> GetAllBands();

        public Task<SalaryTaxCalculationData> GetCalculatedSalaryTaxDataAsync(
            int annualGrossSalary,
            CancellationToken cancellationToken
        );
    }
}
