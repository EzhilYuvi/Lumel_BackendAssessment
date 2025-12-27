namespace Lumel_BackendAssessment.Domain.Entities
{
    public class Product
    {
        public string? Id { get; set; }
        public string ProductId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
    }
}
