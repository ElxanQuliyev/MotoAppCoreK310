using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Title = "Kaska",
                    Description = "Lorem",
                    PhotoUrl = "test1.jpg"
                },
                new Category()
                {
                    Id = 2,
                    Title = "Tshirt",
                    Description = "Lorem Tshirt",
                    PhotoUrl = "test2.jpg"
                }
                );
            builder.Entity<Product>().HasData(
            new Product()
            {
                Id = 1,
                Name = "Product 1",
                Description = "Lorem",
                PhotoUrl = "test1.jpg",
                Price=2500,
                CategoryId=1,
            },
            new Product()
            {
                Id = 2,
                Name = "Product 2",
                Description = "Lorem",
                PhotoUrl = "test2.jpg",
                Price = 2300,
                CategoryId = 2,
            }
            );
        }
    }
}