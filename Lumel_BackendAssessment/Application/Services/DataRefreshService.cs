using Lumel_BackendAssessment.Domain.Entities;
using Lumel_BackendAssessment.Infrastructure.Csv;
using Lumel_BackendAssessment.Infrastructure.Persistence.RavenDb;
using Raven.Client.Documents.BulkInsert;

namespace Lumel_BackendAssessment.Application.Services
{
    public class DataRefreshService(SalesCsvImporter csvImporter)
    {
        private readonly SalesCsvImporter _csvImporter = csvImporter;

        public async Task RefreshAsync(Stream csvStream)
        {
            var (orders, products, customers) = _csvImporter.Parse(csvStream);

            using var bulkInsert = DocumentStoreHolder.Store.BulkInsert(
                new BulkInsertOptions
                {
                    SkipOverwriteIfUnchanged = true
                });

            foreach (var order in orders)
                await bulkInsert.StoreAsync(order);

            foreach (var product in products)
                await bulkInsert.StoreAsync(product);

            foreach (var customer in customers)
                await bulkInsert.StoreAsync(customer);
        }
    }
}
