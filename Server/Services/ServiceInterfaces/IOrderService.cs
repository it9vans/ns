using Shared;

namespace Server.Services.ServiceInterfaces
{
    public interface IOrderService
    {
        List<OrderDTO> GetOrders();
        bool AddOrder(OrderCreateDTO orderCreateDTO);
        bool EditOrder(long id, OrderDTO orderDTO);
        bool DeleteOrder(long id);
    }
}
