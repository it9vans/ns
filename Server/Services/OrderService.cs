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
        
        public OrderDTO[] GetOrders()
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

            return ordersList.ToArray();
        }

        public OrderDTO AddOrder(OrderCreateDTO orderCreateDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            Order newOrder = new Order();
            newOrder.Customer = orderCreateDTO.Customer;
            //newOrder.OrderNumber = String.Join("_", $"{DateTime.Now.ToString("yy")}", $"{DateTime.Now.ToString("MM")}", $"{}");
            newOrder.CreationDate = DateTime.Now;
            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();

            //createdOrder = dbContext.Orders.
            OrderDTO responseProduct = new OrderDTO(newOrder);
            return responseProduct;
        }

        public OrderDTO EditOrder(long id, OrderDTO orderDTO)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.Products.Any(p => p.Id == id))
            {
                return null;
            }
            Order editableProduct = dbContext.Orders.First(p => p.Id == id);
            editableProduct.Customer = orderDTO.Customer;
            dbContext.SaveChanges();
            OrderDTO responseOrder = new OrderDTO(dbContext.Orders.First(p => p.Id == id));
            return responseOrder;
        }

        public void DeleteOrder(long id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            Order deletableOrder = dbContext.Orders.First(p => p.Id == id);
            dbContext.Orders.Remove(deletableOrder);
            dbContext.SaveChanges();
        }
    }
}
