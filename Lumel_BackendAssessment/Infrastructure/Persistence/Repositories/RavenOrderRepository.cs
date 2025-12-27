using Lumel_BackendAssessment.Application.Interfaces;
using Lumel_BackendAssessment.Domain.Entities;
using Lumel_BackendAssessment.Infrastructure.Persistence.RavenDb;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Lumel_BackendAssessment.Infrastructure.Repositories
{
    public class RavenOrderRepository : IOrderRepository
    {
        public async Task AddAsync(IEnumerable<Order> orders)
        {
            using var bulk = DocumentStoreHolder.Store.BulkInsert();

            foreach (var order in orders)
            {
                await bulk.StoreAsync(order);
            }
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
