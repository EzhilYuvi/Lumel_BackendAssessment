using Lumel_BackendAssessment.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lumel_BackendAssessment.Controllers
{
    [ApiController]
    [Route("api/analytics")]
    public class AnalyticsController : ControllerBase
    {
        private readonly RevenueCalculationService _service;

        public AnalyticsController(RevenueCalculationService service)
        {
            _service = service;
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetTotalRevenue(DateTime from, DateTime to)
        {
            var result = await _service.GetTotalRevenueAsync(from, to);
            return Ok(result);
        }

        [HttpGet("revenue/by-product")]
        public async Task<IActionResult> ByProduct(DateTime from, DateTime to)
        {
            return Ok(await _service.GetRevenueByProductAsync(from, to));
        }

        [HttpGet("revenue/by-category")]
        public async Task<IActionResult> ByCategory(DateTime from, DateTime to)
        {
            return Ok(await _service.GetRevenueByCategoryAsync(from, to));
        }

        [HttpGet("revenue/by-region")]
        public async Task<IActionResult> ByRegion(DateTime from, DateTime to)
        {
            return Ok(await _service.GetRevenueByRegionAsync(from, to));
        }
    }
}
