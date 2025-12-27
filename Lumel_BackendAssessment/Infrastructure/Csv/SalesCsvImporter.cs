using Lumel_BackendAssessment.Domain.Entities;
using System.Globalization;

namespace Lumel_BackendAssessment.Infrastructure.Csv
{
    public class SalesCsvImporter
    {
        public (
            List<Order> Orders,
            List<Product> Products,
            List<Customer> Customers
        ) Parse(Stream csvStream)
        {
            using var reader = new StreamReader(csvStream);

            // Skip header
            reader.ReadLine();

            var orders = new List<Order>();
            var products = new Dictionary<string, Product>();
            var customers = new Dictionary<string, Customer>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var cols = line.Split(',');

                var orderId = cols[0];
                var productId = cols[1];
                var customerId = cols[2];

                if (!products.ContainsKey(productId))
                {
                    products[productId] = new Product
                    {
                        Id = $"products/{productId}",
                        ProductId = productId,
                        Name = cols[3],
                        Category = cols[4]
                    };
                }

                if (!customers.ContainsKey(customerId))
                {
                    customers[customerId] = new Customer
                    {
                        Id = $"customers/{customerId}",
                        CustomerId = customerId,
                        Name = cols[12],
                        Email = cols[13],
                        Address = cols[14]
                    };
                }

                orders.Add(new Order
                {
                    Id = $"orders/{orderId}",
                    OrderId = orderId,
                    ProductId = productId,
                    CustomerId = customerId,
                    Region = cols[5],
                    DateOfSale = DateTime.Parse(cols[6], CultureInfo.InvariantCulture),
                    Quantity = int.Parse(cols[7]),
                    UnitPrice = decimal.Parse(cols[8]),
                    Discount = decimal.Parse(cols[9]),
                    ShippingCost = decimal.Parse(cols[10])
                });
            }

            return (orders, products.Values.ToList(), customers.Values.ToList());
        }
    }
}
