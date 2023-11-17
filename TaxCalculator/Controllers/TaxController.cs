using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ITaxBandService _taxBandService;
        private readonly ILogger _logger;

        public TaxController(
            ITaxBandService taxBandService,
            ILogger logger
        )
        {
            _taxBandService = taxBandService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{annualGrossSalary:int}")]
        public async Task<ActionResult> GetCalculatedTax(
            [FromRoute][Range(1, int.MaxValue)] int annualGrossSalary,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _taxBandService.GetCalculatedSalaryTaxDataAsync(annualGrossSalary, cancellationToken);
            return Ok(result);
        }
    }
}