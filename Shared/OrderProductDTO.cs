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
        public string ProductName { get; set; }
        public long ProductsCount { get; set; }
        public long? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderProductDTO() { }
        public OrderProductDTO(OrderProduct orderProduct, string productName) 
        {
            Id = orderProduct.Id;
            ProductName = productName;
            ProductsCount = orderProduct.ProductsCount;
            CreatorId = orderProduct.CreatorId;
            CreationDate = orderProduct.CreationDate;
        }
    }
}
