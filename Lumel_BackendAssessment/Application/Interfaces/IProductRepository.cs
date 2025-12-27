using Lumel_BackendAssessment.Domain.Entities;

namespace Lumel_BackendAssessment.Application.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(IEnumerable<Product> products);
    }
}
