using BusinessLogic.Exceptions;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Data.Entities;
using TaxCalculator.Data;

namespace BusinessLogic.Services
{
    public class TaxBandService : ITaxBandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaxBandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SalaryTaxCalculationData> GetCalculatedSalaryTaxDataAsync(
            int annualGrossSalary,
            CancellationToken cancellationToken
        )
        {
            var taxBands = (await _unitOfWork.TaxBandRepository.GetAllAsync(cancellationToken))
                .Where(x => annualGrossSalary >= x.BottomLimit)
                .ToArray();

            if (!taxBands.Any())
            {
                throw new DataNotFoundException("No tax bands were found");
            }

            var annualTaxPaid = CalculateAnnualTax(annualGrossSalary, taxBands);

            return new SalaryTaxCalculationData
            {
                GrossAnnualSalary = annualGrossSalary,
                GrossMonthlySalary = Math.Round((decimal)annualGrossSalary / 12, 2),
                NetAnnualSalary = annualGrossSalary - annualTaxPaid,
                NetMonthlySalary = Math.Round((annualGrossSalary - annualTaxPaid) / 12, 2),
                AnnualTaxPaid = Math.Round(annualTaxPaid, 2),
                MonthlyTaxPaid = Math.Round(annualTaxPaid / 12, 2)
            };
        }

        private decimal CalculateAnnualTax(decimal annualSalary, IEnumerable<TaxBand> taxBands)
        {
            return (taxBands
                .Select(band => new { band, taxableIncomeInBand = GetTaxableIncomeInBand(annualSalary, band) })
                .Where(x => x.taxableIncomeInBand > 0)
                .Select(x => x.taxableIncomeInBand * x.band.Rate / 100))
                .Sum();
        }

        private decimal GetTaxableIncomeInBand(decimal annualSalary, TaxBand band)
        {
            return Math.Min(annualSalary, band.UpperLimit) - (band.BottomLimit == 0 ? 0 : (band.BottomLimit - 1));
        }
    }
}




