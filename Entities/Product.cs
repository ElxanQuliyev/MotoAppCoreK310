using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Product:BaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; } = null!;
        [MaxLength(350)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        [MaxLength(650)]
        public string? PhotoUrl { get; set; }
        public bool IsFeature { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual List<SaleProduct> SaleProducts { get; set; } 
    }

}
