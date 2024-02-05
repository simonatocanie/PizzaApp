using Microsoft.EntityFrameworkCore;
using PizzaApp.Domain;

namespace PizzaApp.DataAccess.Helpers
{
    public class ProductSizeState
    {
        public ProductSize ProductSize { get; set; }
        public EntityState EntityState { get; set; }
    }
}
