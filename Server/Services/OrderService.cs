using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Services.ServiceInterfaces;
using Shared;

namespace Server.Services
{
    public class OrderService : IOrderService
    {
        IDbContextFactory<ApplicationDbContext> dbContextFactory;
        public OrderService(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            dbContextFactory = dbContext;
        }
        
        public List<OrderDTO> GetOrders()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.Orders.Any())
            {
                return null;
            }
            List<OrderDTO> ordersList = new List<OrderDTO>();
            foreach (var order in dbContext.Orders) 
            {
                OrderDTO orderDTO = new OrderDTO(order);
                ordersList.Add(orderDTO);
            }

            return ordersList;
        }

        public bool AddOrder(OrderCreateDTO orderCreateDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            Order newOrder = new Order();
            newOrder.Customer = orderCreateDTO.Customer;
            //newOrder.OrderNumber = String.Join("_", $"{DateTime.Now.ToString("yy")}", $"{DateTime.Now.ToString("MM")}", $"{}");
            //CreatorId
            newOrder.CreationDate = DateTime.Now;
            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();

            //createdOrder = dbContext.Orders.
            OrderDTO responseProduct = new OrderDTO(newOrder);
            return true;
        }

        public bool EditOrder(long productId, OrderDTO orderDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.Products.Any(p => p.Id == productId))
            {
                return false;
            }
            Order editableProduct = dbContext.Orders.First(p => p.Id == productId);
            editableProduct.Customer = orderDTO.Customer;
            dbContext.SaveChanges();
            OrderDTO responseOrder = new OrderDTO(dbContext.Orders.First(p => p.Id == productId));
            return true;
        }

        public bool DeleteOrder(long orderId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.Products.Any(p => p.Id == orderId))
            {
                return false;
            }
            Order deletableOrder = dbContext.Orders.First(p => p.Id == orderId);
            dbContext.Orders.Remove(deletableOrder);
            dbContext.SaveChanges();
            return true;
        }
    }
}
