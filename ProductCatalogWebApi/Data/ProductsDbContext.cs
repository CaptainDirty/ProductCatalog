using Microsoft.EntityFrameworkCore;

namespace ProductCatalogWebApi.Data
{
    public class ProductsDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }
    }
}
