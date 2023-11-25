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

        public List<OrderProductDTO> GetOrderProducts(long orderId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.Orders.Any(o => o.Id == orderId))
            {
                return null;
            }
            List<OrderProductDTO> orderProductsList = new List<OrderProductDTO>();
            foreach(var orderProduct in dbContext.OrdersProducts
                .Where(op => op.OrderId == orderId)
                .OrderBy(o => o.Id).ToList())
            {
                OrderProductDTO _orderProductDTO = new OrderProductDTO(orderProduct, orderProduct.Product.ProductName);
                orderProductsList.Add(_orderProductDTO);
            }

            return orderProductsList;
        }

        public OrderProductDTO AddOrderProduct(OrderProductCreateDTO orderProductCreateDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            if(!dbContext.Orders.Any(o => o.Id == orderProductCreateDTO.OrderId))
            {
                return null;
            }
            if (!dbContext.Products.Any(p => p.Id == orderProductCreateDTO.ProductId))
            {
                return null;
            }

            OrderProduct newOrderProduct = new OrderProduct();
            newOrderProduct.OrderId = orderProductCreateDTO.OrderId;
            newOrderProduct.ProductId = orderProductCreateDTO.ProductId;
            newOrderProduct.ProductCount = orderProductCreateDTO.ProductCount;
            newOrderProduct.CreatorId = 1;
            newOrderProduct.CreationDate = DateTime.Now;

            dbContext.OrdersProducts.Add(newOrderProduct);
            dbContext.SaveChanges();
        }

        public OrderProductDTO EditOrderProducts(long orderProductId, int productsCount)
        {

        }

        public void DeleteOrderProduct(long orderId, long productId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            //if (!dbContext.OrdersProducts.Any(op => op.OrderId == orderId && op.OrderId == orderId))
            OrderProduct deletableOrderProduct = dbContext.OrdersProducts.FirstOrDefault(op => op.OrderId == orderId && op.OrderId == orderId);
            dbContext.OrdersProducts.Remove(deletableOrderProduct;
        }
    }
}
