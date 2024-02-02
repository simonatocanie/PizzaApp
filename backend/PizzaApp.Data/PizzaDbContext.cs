using Microsoft.EntityFrameworkCore;
using PizzaApp.Domain;
using System.Reflection;


namespace PizzaApp.Data
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }
        public DbSet<Dough> Doughs { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSize>()
                .HasKey(x => new { x.ProductId, x.SizeId });

            modelBuilder.Entity<ProductSize>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductSizes)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ProductSize>()
                .HasOne(x => x.Size)
                .WithMany(x => x.ProductSizes)
                .HasForeignKey(x => x.SizeId);

            modelBuilder.Entity<Dough>()
                .HasMany(x => x.ProductTypes)
                .WithMany(x => x.Doughs)
                .UsingEntity(x => x.ToTable("DoughProductTypes"));  //only for setting the name for generated table

            modelBuilder.Entity<Ingredient>()
                .HasMany(x => x.Products)
                .WithMany(x => x.Ingredients)
                .UsingEntity(x => x.ToTable("ProductIngredients"));

            modelBuilder.Entity<Dough>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Ingredient>()
              .HasIndex(x => x.Name)
              .IsUnique();

            modelBuilder.Entity<Product>()
              .HasIndex(x => x.Name)
              .IsUnique();

            modelBuilder.Entity<ProductType>()
             .HasIndex(x => x.Name)
             .IsUnique();

            modelBuilder.Entity<Size>()
             .HasIndex(x => x.Name)
             .IsUnique();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
