using Lumel_BackendAssessment.Domain.Entities;

namespace Lumel_BackendAssessment.Application.Interfaces
{
    public interface IOrderRepository
    {
        //CSV import
        Task AddAsync(IEnumerable<Order> orders);

        //revenue calculation
        Task<IReadOnlyList<Order>> GetByDateRangeAsync(DateTime from, DateTime to);

        //refresh mechanism
        //Task DeleteAllAsync();
    }
}
