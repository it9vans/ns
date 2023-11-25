using Shared;

namespace Server.Services.ServiceInterfaces
{
    public interface IOrderProductService
    {
        List<OrderProduct> GetOrderProducts(long orderId);
        OrderProductDTO AddOrderProduct(OrderProductCreateDTO orderProductCreateDTO);
        OrderProductDTO EditOrderProducts(long orderId, long productId, OrderProductDTO orderDTO);
        long DeleteOrderProduct(long orderId, long productId);
    }
}
