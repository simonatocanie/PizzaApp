using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Domain
{
    public class Dough   
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Category>? Category { get; set; } = [];
    }
}
