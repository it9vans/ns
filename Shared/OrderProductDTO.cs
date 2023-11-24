using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class OrderProductDTO
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long ProductCount { get; set; }
        public long? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderProductDTO() { }
        public OrderProductDTO(OrderProduct orderProduct) 
        {
            Id = orderProduct.Id;
            OrderId = orderProduct.OrderId;
            ProductId = orderProduct.ProductId;
            ProductCount = orderProduct.ProductCount;
            CreatorId = orderProduct.CreatorId;
            CreationDate = orderProduct.CreationDate;
        }
    }
}
