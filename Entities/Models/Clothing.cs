using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Clothing")]
    public class Clothing
    {
        [Column("ClothingId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string ClothingName { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }
        public string? Brand { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }
    }
}
