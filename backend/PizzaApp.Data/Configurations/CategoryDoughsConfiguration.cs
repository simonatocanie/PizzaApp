using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApp.Domain;


namespace PizzaApp.Data.Configurations
{
    public class CategoryDoughsConfiguration : IEntityTypeConfiguration<CategoryDough>
    {
        public void Configure(EntityTypeBuilder<CategoryDough> builder)
        {
            builder.HasData([
                 new CategoryDough { CategoryId =1, DoughId = 1},
                 new CategoryDough { CategoryId =1, DoughId = 2}
            ]);
        }
    }
}
