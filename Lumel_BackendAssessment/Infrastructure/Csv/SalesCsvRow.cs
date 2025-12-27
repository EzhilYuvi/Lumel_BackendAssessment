using CsvHelper.Configuration.Attributes;

namespace Lumel_BackendAssessment.Infrastructure.Csv
{
    public class SalesCsvRow
    {
        [Name("Order ID")]
        public string OrderId { get; set; } = default!;

        [Name("Product ID")]
        public string ProductId { get; set; } = default!;

        [Name("Customer ID")]
        public string CustomerId { get; set; } = default!;

        [Name("Product Name")]
        public string ProductName { get; set; } = default!;

        public string Category { get; set; } = default!;
        public string Region { get; set; } = default!;

        [Name("Date of Sale")]
        public DateTime DateOfSale { get; set; }

        [Name("Quantity Sold")]
        public int QuantitySold { get; set; }

        [Name("Unit Price")]
        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        [Name("Shipping Cost")]
        public decimal ShippingCost { get; set; }

        [Name("Payment Method")]
        public string PaymentMethod { get; set; } = default!;

        [Name("Customer Name")]
        public string CustomerName { get; set; } = default!;

        [Name("Customer Email")]
        public string CustomerEmail { get; set; } = default!;

        [Name("Customer Address")]
        public string CustomerAddress { get; set; } = default!;
    }
}
