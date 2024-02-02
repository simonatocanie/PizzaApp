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
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasData
            ([
                new Size { Id = 1, Name = "Mica", Measure = 25 },
                new Size { Id = 2, Name = "Medie", Measure = 30 },
                new Size { Id = 3, Name = "Mare", Measure = 35 },
                new Size { Id = 4, Name = "Party" }
            ]);
        }
    }
}
