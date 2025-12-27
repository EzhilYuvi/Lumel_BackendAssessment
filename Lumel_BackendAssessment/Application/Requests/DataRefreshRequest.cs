using Microsoft.AspNetCore.Http;

namespace Lumel_BackendAssessment.Application.Requests
{
    public class DataRefreshRequest
    {
        public IFormFile File { get; set; } = default!;
    }
}
