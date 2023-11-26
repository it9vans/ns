using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis;
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

        public bool AddOrderProduct(OrderProductCreateDTO orderProductCreateDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            if (!dbContext.OrdersProducts.Any(op => op.OrderId == orderProductCreateDTO.OrderId && op.ProductId == orderProductCreateDTO.ProductId))
            {
                return false;
            }

            OrderProduct newOrderProduct = new OrderProduct();
            newOrderProduct.OrderId = orderProductCreateDTO.OrderId;
            newOrderProduct.ProductId = orderProductCreateDTO.ProductId;
            newOrderProduct.ProductsCount = orderProductCreateDTO.ProductsCount;
            newOrderProduct.CreatorId = 1;
            newOrderProduct.CreationDate = DateTime.Now;

            dbContext.OrdersProducts.Add(newOrderProduct);
            dbContext.SaveChanges();
            return true;
        }

        public bool EditOrderProducts(OrderProductEditDTO orderProductEditDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.OrdersProducts.Any(op => op.OrderId == orderProductEditDTO.OrderId && op.ProductId == orderProductEditDTO.ProductId))
            {
                return false;
            }
            OrderProduct editableOrderProduct = dbContext.OrdersProducts.Find(orderProductEditDTO.Id);
            editableOrderProduct.ProductsCount = orderProductEditDTO.ProductsCount;
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteOrderProduct(long orderId, long productId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.OrdersProducts.Any(op => op.OrderId == orderId && op.ProductId == productId)) //!dbContext.Orders.Any(o => o.Id == orderId) || !dbContext.Products.Any(p => p.Id == productId
            {
                return false;
            }
            
            OrderProduct deletableOrderProduct = dbContext.OrdersProducts.FirstOrDefault(op => op.OrderId == orderId && op.ProductId == productId);
            dbContext.OrdersProducts.Remove(deletableOrderProduct);
            dbContext.SaveChanges();
            return true;
        }
    }
}
