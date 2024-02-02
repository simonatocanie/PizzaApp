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
    public class DoughConfiguration : IEntityTypeConfiguration<Dough>
    {
        public void Configure(EntityTypeBuilder<Dough> builder)
        {
            builder.HasData
            ([
                new Dough { Id = 1, Name = "Traditional" },
                new Dough { Id = 2, Name = "Subtire" }
            ]);
        }
    }
}
