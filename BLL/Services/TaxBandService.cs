using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<TaxBand> GetAllBands()
        {
            return _unitOfWork.TaxBandRepository.GetAll();
        }

        public async Task<SalaryTaxCalculationData> GetCalculatedSalaryTaxDataAsync(
            int annualGrossSalary,
            CancellationToken cancellationToken
        )
        {
            var taxBands = await GetAllBands()
                .AsNoTracking()
                .Where(x => annualGrossSalary >= x.BottomLimit)
                .ToArrayAsync(cancellationToken);

            var annualTaxPaid = CalculateAnnualTax(annualGrossSalary, taxBands);

            return new SalaryTaxCalculationData
            {
                GrossAnnualSalary = annualGrossSalary,
                GrossMonthlySalary = annualGrossSalary / 12,
                NetAnnualSalary = annualGrossSalary - annualTaxPaid,
                NetMonthlySalary = (annualGrossSalary - annualTaxPaid) / 12,
                AnnualTaxPaid = annualTaxPaid,
                MonthlyTaxPaid = annualTaxPaid / 12
            };
        }

        private decimal CalculateAnnualTax(decimal annualSalary, IEnumerable<TaxBand> taxBands)
        {
            decimal taxPaid = 0;

            foreach (var band in taxBands)
            {
                var taxableIncomeInBand = GetTaxableIncomeInBand(annualSalary, band);

                if (taxableIncomeInBand > 0)
                {
                    var bandTax = taxableIncomeInBand * band.Rate / 100;
                    taxPaid += bandTax;
                }
            }

            return taxPaid;
        }

        private decimal GetTaxableIncomeInBand(decimal annualSalary, TaxBand band)
        {
            return Math.Min(annualSalary, band.UpperLimit) - (band.BottomLimit == 0 ? 0 : (band.BottomLimit - 1));
        }
    }
}




