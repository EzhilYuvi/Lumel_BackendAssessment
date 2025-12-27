using Lumel_BackendAssessment.Application.Interfaces;
using Lumel_BackendAssessment.Domain.Entities;
using Lumel_BackendAssessment.Infrastructure.Persistence.RavenDb;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Lumel_BackendAssessment.Infrastructure.Repositories
{
    public class RavenOrderRepository : IOrderRepository
    {
        // Writes intentionally disabled
        public Task AddAsync(IEnumerable<Order> orders)
        {
            throw new NotSupportedException(
                "Order writes are handled via BulkInsert in DataRefreshService.");
        }

        public async Task<IReadOnlyList<Order>> GetByDateRangeAsync(DateTime from, DateTime to)
        {
            using IAsyncDocumentSession session =
                DocumentStoreHolder.Store.OpenAsyncSession();

            return await session.Query<Order>()
                .Where(o => o.DateOfSale >= from && o.DateOfSale <= to)
                .ToListAsync();
        }
    }
}
