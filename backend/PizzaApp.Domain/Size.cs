using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Domain
{
    public class Size
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Measure { get; set; }
        public List<ProductSize> ProductSizes { get; set; } = [];
    }
}
