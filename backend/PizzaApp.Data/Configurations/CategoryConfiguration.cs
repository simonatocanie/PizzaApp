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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            ([
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Bauturi" },
                new Category { Id = 3, Name = "Cafea" },
                new Category { Id = 4, Name = "Sosuri" },
            ]);
        }
    }
}
