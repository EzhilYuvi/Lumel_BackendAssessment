using Lumel_BackendAssessment.Application.Interfaces;
using Lumel_BackendAssessment.Domain.Entities;

namespace Lumel_BackendAssessment.Infrastructure.Repositories
{
    public class RavenProductRepository : IProductRepository
    {
        public Task AddAsync(IEnumerable<Product> products)
        {
            throw new NotSupportedException(
                "Product writes are handled via BulkInsert in DataRefreshService.");
        }
    }
}
