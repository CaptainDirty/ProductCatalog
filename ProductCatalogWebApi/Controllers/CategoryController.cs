using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post()
        {
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
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
