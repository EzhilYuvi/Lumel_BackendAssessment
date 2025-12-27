using Lumel_BackendAssessment.Domain.Entities;

namespace Lumel_BackendAssessment.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(IEnumerable<Order> orders);
        Task<IReadOnlyList<Order>> GetByDateRangeAsync(DateTime from, DateTime to);
    }
}
