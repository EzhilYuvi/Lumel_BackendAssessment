using Lumel_BackendAssessment.Application.Dtos;
using Lumel_BackendAssessment.Application.Interfaces;

namespace Lumel_BackendAssessment.Application.Services
{
    public class RevenueCalculationService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;

        public RevenueCalculationService(
            IOrderRepository orderRepo,
            IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        public async Task<decimal> GetTotalRevenueAsync(DateTime from, DateTime to)
        {
            var orders = await _orderRepo.GetByDateRangeAsync(from, to);
            return orders.Sum(o => o.Quantity * o.UnitPrice);
        }

        public async Task<IReadOnlyList<RevenueByKeyDto>> GetRevenueByProductAsync(DateTime from, DateTime to)
        {
            var orders = await _orderRepo.GetByDateRangeAsync(from, to);
            var products = await _productRepo.GetAllAsync();

            return orders
                .GroupBy(o => o.ProductId)
                .Select(g =>
                {
                    var product = products.First(p => p.Id == g.Key);
                    return new RevenueByKeyDto
                    {
                        Key = product.Name,
                        Revenue = g.Sum(x => x.Quantity * x.UnitPrice)
                    };
                })
                .ToList();
        }

        public async Task<IReadOnlyList<RevenueByKeyDto>> GetRevenueByCategoryAsync(DateTime from, DateTime to)
        {
            var orders = await _orderRepo.GetByDateRangeAsync(from, to);
            var products = await _productRepo.GetAllAsync();

            return orders
                .GroupBy(o => products.First(p => p.Id == o.ProductId).Category)
                .Select(g => new RevenueByKeyDto
                {
                    Key = g.Key,
                    Revenue = g.Sum(x => x.Quantity * x.UnitPrice)
                })
                .ToList();
        }

        public async Task<IReadOnlyList<RevenueByKeyDto>> GetRevenueByRegionAsync(DateTime from, DateTime to)
        {
            var orders = await _orderRepo.GetByDateRangeAsync(from, to);

            return orders
                .GroupBy(o => o.Region)
                .Select(g => new RevenueByKeyDto
                {
                    Key = g.Key,
                    Revenue = g.Sum(x => x.Quantity * x.UnitPrice)
                })
                .ToList();
        }
    }
}
