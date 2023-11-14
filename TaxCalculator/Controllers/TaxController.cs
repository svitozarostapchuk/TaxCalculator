using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TaxCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ITaxBandService _taxBandService;

        public TaxController(
            ITaxBandService taxBandService
        )
        {
            _taxBandService = taxBandService;
        }

        [HttpGet]
        [Route("{annualGrossSalary:int}")]
        public async Task<ActionResult> GetCalculatedTax(
            [FromRoute] int annualGrossSalary,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _taxBandService.GetCalculatedSalaryTaxDataAsync(annualGrossSalary, cancellationToken);
            return Ok(result);
        }
    }
}