using Lumel_BackendAssessment.Application.Interfaces;
using Lumel_BackendAssessment.Infrastructure.Csv;

namespace Lumel_BackendAssessment.Application.Services
{
    public class DataRefreshService(
        ILogger<DataRefreshService> logger,
        SalesCsvImporter importer,
        IOrderRepository orders,
        IProductRepository products,
        ICustomerRepository customers)
    {
        private readonly ILogger<DataRefreshService> _logger = logger;
        private readonly SalesCsvImporter _importer = importer;
        private readonly IOrderRepository _orders = orders;
        private readonly IProductRepository _products = products;
        private readonly ICustomerRepository _customers = customers;

        public async Task RefreshAsync(Stream csvStream)
        {
            try
            {
                _logger.LogInformation("Data refresh started");

                var (orders, products, customers) = _importer.Parse(csvStream);

                await _products.AddAsync(products);
                await _customers.AddAsync(customers);
                await _orders.AddAsync(orders);

                _logger.LogInformation(
                    "Data refresh completed successfully. Orders: {Orders}, Products: {Products}, Customers: {Customers}",
                    orders.Count, products.Count, customers.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Data refresh failed");
                throw;
            }
        }
    }
}
