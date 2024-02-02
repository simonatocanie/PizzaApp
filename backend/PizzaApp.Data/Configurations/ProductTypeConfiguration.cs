using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData
            ([
                new ProductType { Id = 1, Name = "Pizza" },
                new ProductType { Id = 2, Name = "Bauturi" },
                new ProductType { Id = 3, Name = "Cafea" },
                new ProductType { Id = 4, Name = "Sosuri" },
            ]);
        }
    }
}
