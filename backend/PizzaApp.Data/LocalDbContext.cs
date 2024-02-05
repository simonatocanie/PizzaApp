using Microsoft.EntityFrameworkCore;
using PizzaApp.Domain;
using System.Reflection;


namespace PizzaApp.Data
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }
        public DbSet<Dough> Doughs { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dough>()
                .HasMany(x => x.Category)
                .WithMany(x => x.Doughs)
                .UsingEntity<CategoryDough>(); 

            modelBuilder.Entity<Dough>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(x => x.Name)
                .IsUnique();

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

            modelBuilder.Entity<Product>()
               .HasIndex(x => x.Name)
               .IsUnique();

            modelBuilder.Entity<Size>()
               .HasIndex(x => x.Name)
               .IsUnique();

            modelBuilder.Entity<Ingredient>()
               .HasMany(x => x.Products)
               .WithMany(x => x.Ingredients)
               .UsingEntity<ProductIngredient>();

            modelBuilder.Entity<ProductIngredient>()
               .HasKey(x => new { x.ProductId, x.IngredientId });

            modelBuilder.Entity<Ingredient>()
              .HasIndex(x => x.Name)
              .IsUnique();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
