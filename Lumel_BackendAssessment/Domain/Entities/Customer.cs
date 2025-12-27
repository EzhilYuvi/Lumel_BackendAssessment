namespace Lumel_BackendAssessment.Domain.Entities
{
    public class Customer
    {
        public string? Id { get; set; }
        public string CustomerId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Region { get; set; } = default!;
    }
}
