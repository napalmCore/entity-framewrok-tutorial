namespace EFTuto.Models
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly EFTutoDbContext _appDbContext;

        public OrderStatusRepository(EFTutoDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<OrderStatus> GetOrderStatuses => _appDbContext.OrderStatuses;

        public OrderStatus GetOrderStatusById(int id) => _appDbContext.OrderStatuses.FirstOrDefault(p => p.Id == id);
    }
}