namespace EFTuto.Models
{
    public interface IOrderStatusRepository
    {
        IEnumerable<OrderStatus> GetOrderStatuses { get; }
        OrderStatus GetOrderStatusById(int id);
    }
}