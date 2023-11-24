using Shared;

namespace Server.Services.ServiceInterfaces
{
    public interface IOrderService
    {
        OrderDTO[] GetOrders();
        OrderDTO AddOrder(OrderCreateDTO orderCreateDTO);
        OrderDTO EditOrder(long id, OrderDTO orderDTO);
        void DeleteOrder(long id);
    }
}
