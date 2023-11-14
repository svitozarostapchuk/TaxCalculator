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

        public TaxController(
            ITaxBandService taxBandService
        )
        {
            _taxBandService = taxBandService;
        }

        [HttpGet]
        [Route("{annualGrossSalary:int}")]
        public async Task<ActionResult> GetCalculatedTax(
            [FromRoute][Required][Range(1, int.MaxValue)] int annualGrossSalary,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _taxBandService.GetCalculatedSalaryTaxDataAsync(annualGrossSalary, cancellationToken);
            return Ok(result);
        }
    }
}