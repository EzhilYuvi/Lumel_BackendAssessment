using Lumel_BackendAssessment.Application.Interfaces;
using Lumel_BackendAssessment.Domain.Entities;
using Lumel_BackendAssessment.Infrastructure.Persistence.RavenDb;
using Raven.Client.Documents.Session;

namespace Lumel_BackendAssessment.Infrastructure.Repositories
{
    public class RavenCustomerRepository : ICustomerRepository
    {
        public async Task AddAsync(IEnumerable<Customer> customers)
        {
            using var session = DocumentStoreHolder.Store.OpenAsyncSession();

            foreach (var customer in customers)
            {
                await session.StoreAsync(customer);
            }

            await session.SaveChangesAsync();
        }
    }
}
