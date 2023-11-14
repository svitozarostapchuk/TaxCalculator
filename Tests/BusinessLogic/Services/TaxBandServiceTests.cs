using BusinessLogic.Exceptions;
using BusinessLogic.Services;
using Data.Entities;
using Moq;
using TaxCalculator.Data;

namespace Tests.BusinessLogic.Services
{
    [TestFixture]
    public class TaxBandServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private TaxBandService _taxBandService;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            var taxBands = new List<TaxBand>
            {
                new TaxBand { Id = 1, BottomLimit = 0, UpperLimit = 5000, Rate = 0 },
                new TaxBand { Id = 2, BottomLimit = 5001, UpperLimit = 20000, Rate = 20 },
                new TaxBand { Id = 3, BottomLimit = 20001, UpperLimit = int.MaxValue, Rate = 40 }
            };

            _mockUnitOfWork.Setup(x => x.TaxBandRepository.GetAllAsync(It.IsAny<CancellationToken>()))
                           .ReturnsAsync(taxBands);

            _taxBandService = new TaxBandService(_mockUnitOfWork.Object);
        }

        [TestCase(1, new[] { 1, 0.0833333333333333, 1, 0.0833333333333333, 0, 0 })]
        [TestCase(5000, new[] { 5000, 416.6666666666667, 5000, 416.6666666666667, 0, 0 })]
        [TestCase(5001, new[] { 5001, 416.75, 5000.8, 416.73333333333335, 0.2, 0.016666666666666666 })]
        [TestCase(20000, new[] { 20000, 1666.6666666666667, 17000, 1416.6666666666667, 3000, 250 })]
        [TestCase(20001, new[] { 20001, 1666.75, 17000.6, 1416.7166666666667, 3000.4, 250.03333333333333 })]
        [TestCase(int.MaxValue, new[] { int.MaxValue, 178956970.58333334, 1288495188.2, 107374599.01666667, 858988458.8, 71582371.56666666 })]
        public async Task GetCalculatedSalaryTaxDataAsync_ReturnsExpectedResult(int annualGrossSalary,
            double[] expectedTaxCalculationData)
        {
            // Act
            var actualTaxCalculationData = await _taxBandService.GetCalculatedSalaryTaxDataAsync(annualGrossSalary, CancellationToken.None);

            // Assert
            Assert.AreEqual((double)actualTaxCalculationData.GrossAnnualSalary, expectedTaxCalculationData[0]);
            Assert.AreEqual((double)actualTaxCalculationData.GrossMonthlySalary, expectedTaxCalculationData[1], 0.00000001d);
            Assert.AreEqual((double)actualTaxCalculationData.NetAnnualSalary, expectedTaxCalculationData[2], 0.00000001d);
            Assert.AreEqual((double)actualTaxCalculationData.NetMonthlySalary, expectedTaxCalculationData[3], 0.00000001d);
            Assert.AreEqual((double)actualTaxCalculationData.AnnualTaxPaid, expectedTaxCalculationData[4], 0.00000001d);
            Assert.AreEqual((double)actualTaxCalculationData.MonthlyTaxPaid, expectedTaxCalculationData[5], 0.00000001d);
        }

        [Test]
        public async Task WhenNoTaxBands_GetCalculatedSalaryTaxDataAsync_ThrowsException()
        {
            // Arrange
            var testSalary = 30000;
            _mockUnitOfWork.Setup(x => x.TaxBandRepository.GetAllAsync(It.IsAny<CancellationToken>()))
                           .ReturnsAsync(Array.Empty<TaxBand>());

            // Act
            var exception = Assert.ThrowsAsync<DataNotFoundException>(
                async () => await _taxBandService.GetCalculatedSalaryTaxDataAsync(testSalary, CancellationToken.None)
            );

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No tax bands were found"));
        }
    }
}