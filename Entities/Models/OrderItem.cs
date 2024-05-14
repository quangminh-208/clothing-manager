using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Column("OrderItemId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [ForeignKey(nameof(UserOrder))]
        public int OrderId { get; set; }
        public UserOrder UserOrder { get; set; }

        [ForeignKey(nameof(Clothing))]
        public int ClothingId { get; set; }
        public Clothing Clothing { get; set; }
    }
}
