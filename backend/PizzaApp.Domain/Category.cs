using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace PizzaApp.Domain
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Product>? Products { get; set; } = [];
        public List<Dough> Doughs { get; set; } = [];
    }
}
