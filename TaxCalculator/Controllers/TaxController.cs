using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TaxCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ILogger<TaxController> _logger;
        private readonly ITaxBandService _taxBandService;

        public TaxController(
            ILogger<TaxController> logger,
            ITaxBandService taxBandService
        )
        {
            _logger = logger;
            _taxBandService = taxBandService;
        }

        [HttpGet]
        [Route("{annualGrossSalary:int}")]
        public async Task<ActionResult> GetCalculatedTax(
            [FromRoute] int annualGrossSalary,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _taxBandService.GetCalculatedSalaryTaxDataAsync(annualGrossSalary, default(CancellationToken));
            return Ok(result);
        }
    }
}