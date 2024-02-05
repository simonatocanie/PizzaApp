using Microsoft.EntityFrameworkCore;
using PizzaApp.Domain;

namespace PizzaApp.DataAccess.Helpers
{
    public class ProductIngredientState
    {
        public ProductIngredient ProductIngredient { get; set; }
        public EntityState EntityState { get; set; }
    }
}
