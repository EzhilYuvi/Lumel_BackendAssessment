using Lumel_BackendAssessment.Application.Requests;
using Lumel_BackendAssessment.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lumel_BackendAssessment.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataRefreshController(DataRefreshService dataRefreshService) : ControllerBase
    {
        private readonly DataRefreshService _dataRefreshService = dataRefreshService;

        [HttpPost("refresh")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Refresh([FromForm] DataRefreshRequest request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest("CSV file is required.");

            using var stream = request.File.OpenReadStream();
            await _dataRefreshService.RefreshAsync(stream);

            return Ok(new { message = "Data refresh completed successfully." });
        }
    }
}
