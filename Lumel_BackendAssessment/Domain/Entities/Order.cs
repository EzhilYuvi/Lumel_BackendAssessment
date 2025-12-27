namespace Lumel_BackendAssessment.Domain.Entities
{
    public class Order
    {
        public string? Id { get; set; }
        public string OrderId { get; set; } = default!;
        public string ProductId { get; set; } = default!;
        public string CustomerId { get; set; } = default!;

        public DateTime DateOfSale { get; set; }
        public string Region { get; set; } = default!;
        public int Quantity { get; set; }
        public int QuantitySold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal ShippingCost { get; set; }

        public string PaymentMethod { get; set; } = default!;

        // Derived business value
        public decimal CalculateRevenue()
        {
            return (QuantitySold * UnitPrice * (1 - Discount)) + ShippingCost;
        }
    }
}
