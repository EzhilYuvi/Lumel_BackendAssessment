using Lumel_BackendAssessment.Application.Interfaces;

namespace Lumel_BackendAssessment.Application.Services
{
    public class RevenueCalculationService
    {
        private readonly IOrderRepository _orderRepository;

        public RevenueCalculationService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<decimal> CalculateTotalRevenueAsync(DateTime from, DateTime to)
        {
            var orders = await _orderRepository.GetByDateRangeAsync(from, to);

            return orders.Sum(o => o.CalculateRevenue());
        }
    }
}
