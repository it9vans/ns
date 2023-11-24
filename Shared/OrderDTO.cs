using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Shared
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public string Customer { get; set; }
        public string OrderNumber { get; set; }
        public long? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderDTO() { }
        public OrderDTO(Order order)
        {
            Id = order.Id;
            Customer = order.Customer;
            OrderNumber = order.OrderNumber;
            CreatorId = order.CreatorId;
            CreationDate = order.CreationDate;
        }
    }
}
