using Microsoft.AspNetCore.Mvc;
using ProductCatalogData.Models;
using ProductCatalogWebApi.Data;

namespace ProductCatalogWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ProductsDbContext _productsDbContext;
        public CategoryController(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }

        [HttpGet]
        public List<Category> Get()
        {
            var categories = _productsDbContext.Categories.ToList();

            return categories;
        }
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = _productsDbContext.Categories.FirstOrDefault(x => x.Id == id);

            return category;
        }
        [HttpPost]
        [Route("{id}")]
        public IActionResult Post(int id, Category category)
        {
            var existCategory = _productsDbContext.Categories.FirstOrDefault(c => c.Id == id);
            
            if(existCategory == null)
            {
                return NotFound();
            }

            existCategory.Name = category.Name;

            _productsDbContext.Categories.Update(existCategory);
            _productsDbContext.SaveChanges();

            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Category category)
        {
            _productsDbContext.Categories.Add(category);
            _productsDbContext.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var existCategory = _productsDbContext.Categories.FirstOrDefault(c => c.Id == id);

            if (existCategory == null)
            {
                return NotFound();
            }

            _productsDbContext.Categories.Remove(existCategory);
            _productsDbContext.SaveChanges();

            return Ok();
        }
    }
}
