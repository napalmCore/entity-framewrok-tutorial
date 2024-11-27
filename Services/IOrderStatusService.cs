namespace EFTuto.Models
{
    public interface IOrderStatusService
    {
        IEnumerable<OrderStatus> GetOrderStatuses { get; }
        OrderStatus GetOrderStatusById(int id);
    }
}