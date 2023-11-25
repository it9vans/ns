using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Shared
{
    public class OrderProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public long ProductCount { get; set; }
        public long? CreatorId { get; set; }
        
        public DateTime CreationDate { get; set; }


    }
}
