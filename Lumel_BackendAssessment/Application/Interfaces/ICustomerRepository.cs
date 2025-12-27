using Lumel_BackendAssessment.Domain.Entities;

namespace Lumel_BackendAssessment.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(IEnumerable<Customer> customers);
    }
}
