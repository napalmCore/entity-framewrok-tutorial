namespace EFTuto.Models
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public IEnumerable<OrderStatus> GetOrderStatuses => _orderStatusRepository.GetOrderStatuses;

        public OrderStatus GetOrderStatusById(int id) => _orderStatusRepository.GetOrderStatusById(id);
    }
}