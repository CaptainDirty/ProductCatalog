using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProductCatalogClient.Models;
using ProductCatalogClient.Models.Config;
using System.Diagnostics;

namespace ProductCatalogClient.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IOptions<ProductCatalogWebApiConfig> _pcConfig;

        public CategoryController(ILogger<CategoryController> logger, IOptions<ProductCatalogWebApiConfig> sc)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}