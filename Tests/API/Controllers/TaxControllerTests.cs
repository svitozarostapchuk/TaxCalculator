﻿using BusinessLogic.Exceptions;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using TaxCalculator.Controllers;

namespace Tests.API.Controllers
{
    [TestFixture]
    public class TaxControllerTests
    {
        private Mock<ITaxBandService> _mockTaxBandService;
        private Mock<ILogger> _mockLogger;
        private TaxController _taxController;

        [SetUp]
        public void Setup()
        {
            _mockTaxBandService = new Mock<ITaxBandService>();
            _mockLogger = new Mock<ILogger>();
            _taxController = new TaxController(_mockTaxBandService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetCalculatedTax_WithValidAnnualGrossSalary_ReturnsOkResult()
        {
            // Arrange
            var annualGrossSalary = 24000;
            var expectedResult = new SalaryTaxCalculationData()
            {
                GrossAnnualSalary = annualGrossSalary,
                NetAnnualSalary = 19400,
                GrossMonthlySalary = 2000,
                NetMonthlySalary = 1616.67m,
                AnnualTaxPaid = 4600,
                MonthlyTaxPaid = 383.33m,
            };
            _mockTaxBandService.Setup(x => x.GetCalculatedSalaryTaxDataAsync(annualGrossSalary, It.IsAny<CancellationToken>()))
                               .ReturnsAsync(expectedResult);

            // Act
            var result = await _taxController.GetCalculatedTax(annualGrossSalary, CancellationToken.None) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(expectedResult, result.Value);
        }

        [Test]
        public async Task GetCalculatedTax_WithExceptionThrown_Returns500Result()
        {
            // Arrange
            var annualGrossSalary = 24000;
            var expectedResult = "Internal Server Error";
            _mockTaxBandService.Setup(x => x.GetCalculatedSalaryTaxDataAsync(annualGrossSalary, It.IsAny<CancellationToken>()))
                               .ThrowsAsync(new DataNotFoundException());

            // Act
            var result = await _taxController.GetCalculatedTax(annualGrossSalary, CancellationToken.None) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.AreEqual(expectedResult, result.Value);
        }
    }
}
