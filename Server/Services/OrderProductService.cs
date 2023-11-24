using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Server.Data;
using Shared;

namespace Server.Services
{
    public class OrderProductService
    {
        IDbContextFactory<ApplicationDbContext> dbContextFactory;
        public OrderProductService(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            dbContextFactory = dbContext;
        }

        public List<OrderProduct> GetOrdersProducts(long orderId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.Orders.Any())
            {
                return null;
            }
            List<OrderProduct> ordersList = dbContext.OrdersProducts
                .Where(op => op.OrderId == orderId)
                .OrderBy(o => o.Id).ToList();

            return ordersList;
        }

        public OrderProductDTO AddOrderProduct(OrderCreateDTO orderCreateDTO)
        {

        }

        public OrderProductDTO EditOrderProducts(long orderId, long productId, OrderProductDTO orderDTO)
        {

        }

        public void DeleteOrderProduct(long orderId, long productId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.OrdersProducts.Where(op => op.OrderId == orderId && op => op.OrderId == orderId).Any())
        }
    }
}
