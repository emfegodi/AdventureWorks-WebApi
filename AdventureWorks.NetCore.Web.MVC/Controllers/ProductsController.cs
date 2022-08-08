using Microsoft.AspNetCore.Mvc;
using AdventureWorks.NetCore.Repository;
using AdventureWorks.NetCore.Repository.Models;
using Newtonsoft.Json;

namespace AdventureWorks.NetCore.Web.MVC.Controllers
{
    public class ProductsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Product> productList = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7156/Api/Products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);

                }
            }

            return View(productList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Product product = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7156/Api/Products" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        product = JsonConvert.DeserializeObject<Product>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(product);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            Product selectedProduct = new Product();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7156/Api/Products", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    selectedProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
                ViewBag.Message = selectedProduct;
            }
            return View(selectedProduct);
        }
    }
}
