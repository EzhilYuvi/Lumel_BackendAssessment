using Lumel_BackendAssessment.Application.Interfaces;
using Lumel_BackendAssessment.Domain.Entities;
using Lumel_BackendAssessment.Infrastructure.Persistence.RavenDb;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Lumel_BackendAssessment.Infrastructure.Repositories
{
    public class RavenProductRepository : IProductRepository
    {
        public async Task AddAsync(IEnumerable<Product> products)
        {
            using var bulk = DocumentStoreHolder.Store.BulkInsert();

            foreach (var product in products)
            {
                await bulk.StoreAsync(product);
            }
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            using IAsyncDocumentSession session =
                DocumentStoreHolder.Store.OpenAsyncSession();

            return await session.Query<Product>().ToListAsync();
        }
    }
}
