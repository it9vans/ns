using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Shared
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Customer { get; set; }
        public string OrderNumber { get; set; }
        public long? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
