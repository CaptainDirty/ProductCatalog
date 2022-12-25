using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogWebApi.Data;

namespace ProductCatalogWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductsDbContext _productsDbContext;
        public ProductController(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }

        [HttpGet]
        public List<Product> Get()
        {
            var products = _productsDbContext.Products
                .Include(x => x.Category)
                .ToList();

            return products;
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _productsDbContext.Products.FirstOrDefault(x => x.Id == id);

            return product;
        }
        [HttpPost("{id}")]
        public IActionResult Post(int id, Product product)
        {
            var existProduct = _productsDbContext.Products.FirstOrDefault(c => c.Id == id);

            if (existProduct == null)
            {
                return NotFound();
            }

            existProduct.Name = product.Name;
            existProduct.Type = product.Type;
            existProduct.ExpirationDate = product.ExpirationDate;
            existProduct.CategoryId = product.CategoryId;

            _productsDbContext.Products.Update(existProduct);
            _productsDbContext.SaveChanges();

            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Product product)
        {
            _productsDbContext.Products.Add(product);
            _productsDbContext.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existProduct = _productsDbContext.Products.FirstOrDefault(c => c.Id == id);

            if (existProduct == null)
            {
                return NotFound();
            }

            _productsDbContext.Products.Remove(existProduct);
            _productsDbContext.SaveChanges();

            return Ok();
        }
    }
}
