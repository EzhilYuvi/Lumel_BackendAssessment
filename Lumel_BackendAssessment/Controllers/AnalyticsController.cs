using Lumel_BackendAssessment.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lumel_BackendAssessment.Controllers
{
    [ApiController]
    [Route("api/analytics")]
    public class AnalyticsController(RevenueCalculationService revenueService) : ControllerBase
    {
        private readonly RevenueCalculationService _revenueService = revenueService;

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenue(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            if (from > to)
                return BadRequest("'from' date must be earlier than 'to' date.");

            var totalRevenue = await _revenueService.CalculateTotalRevenueAsync(from, to);

            return Ok(new
            {
                from,
                to,
                totalRevenue
            });
        }
    }
}
