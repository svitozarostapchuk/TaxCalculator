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
            [FromRoute][Required][Range(1, int.MaxValue)] int annualGrossSalary,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var result = await _taxBandService.GetCalculatedSalaryTaxDataAsync(annualGrossSalary, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}