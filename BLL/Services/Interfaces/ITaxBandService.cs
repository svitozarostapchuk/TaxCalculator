using BusinessLogic.Models;

namespace BusinessLogic.Services.Interfaces
{
    public interface ITaxBandService
    {
        public Task<SalaryTaxCalculationData> GetCalculatedSalaryTaxDataAsync(
            int annualGrossSalary,
            CancellationToken cancellationToken
        );
    }
}
