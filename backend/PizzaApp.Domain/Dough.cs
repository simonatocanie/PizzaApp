using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Domain
{
    public class Dough   // consider that all type products have same doughs, interest in order
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<ProductType>? ProductTypes { get; set; } = [];
    }
}
