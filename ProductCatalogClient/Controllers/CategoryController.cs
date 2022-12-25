using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductCatalogClient.Models;
using ProductCatalogClient.Models.Config;
using ProductCatalogData.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace ProductCatalogClient.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IOptions<ProductCatalogWebApiConfig> _pcWebApiConfig;

        public CategoryController(ILogger<CategoryController> logger, IOptions<ProductCatalogWebApiConfig> pcWebApiConfig)
        {
            _logger = logger;
            _pcWebApiConfig = pcWebApiConfig;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await GetCategories();
            if (categories == null)
                return View(new List<Category>());
            else
                return View(categories);
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool result = await DeleteCategory(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            bool result = await EditCategory(category);
            if (result)
                return RedirectToAction("Index");
            else
                return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Category result = await GetCategory(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            bool result = await AddCategory(category);
            if (result)
                return RedirectToAction("Index");
            else
                return View();
        }


        private async Task<Category> GetCategory(int id)
        {
            using var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(1) };

            try
            {
                var response = await httpClient.GetAsync(_pcWebApiConfig.Value.Endpoint + "Category/" + id);

                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<Category>(responseData);

                    return result;
                }
            }
            catch { }

            return null;
        }


        private async Task<List<Category>> GetCategories()
        {
            using var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(1) };

            try
            {
                var response = await httpClient.GetAsync(_pcWebApiConfig.Value.Endpoint + "Category");

                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<List<Category>>(responseData);

                    return result;
                }
            }
            catch { }

            return null;
        }

        private async Task<bool> EditCategory(Category category)
        {
            using var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(1) };

            try
            {
                var response = await httpClient.PostAsJsonAsync(_pcWebApiConfig.Value.Endpoint + "Category/" + category.Id, category);
                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    return true;
                }
            }
            catch { }

            return false;
        }

        private async Task<bool> AddCategory(Category category)
        {
            using var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(1) };

            try
            {
                var response = await httpClient.PutAsJsonAsync(_pcWebApiConfig.Value.Endpoint + "Category/", category);
                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    return true;
                }
            }
            catch { }

            return false;
        }

        private async Task<bool> DeleteCategory(int id)
        {
            using var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(1) };

            try
            {
                var response = await httpClient.DeleteAsync(_pcWebApiConfig.Value.Endpoint + "Category/" + id);
                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    return true;
                }
            }
            catch { }

            return false;
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}