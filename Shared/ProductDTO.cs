using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public long? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }

        public ProductDTO() { }
        public ProductDTO(Product product)
        {
            Id = product.Id;
            ProductName = product.ProductName;
            CreatorId = product.CreatorId;
            CreationDate = product.CreationDate;
        }
    }
}
