using Shared;

namespace Server.Services.ServiceInterfaces
{
    public interface IOrderProductService
    {
        List<OrderProduct> GetOrderProducts(long orderId);
        long AddOrderProduct(OrderProductCreateDTO orderProductCreateDTO);
        bool EditOrderProducts(OrderProductEditDTO orderProductEditDTO);
        bool DeleteOrderProduct(long orderId, long productId);
    }
}
