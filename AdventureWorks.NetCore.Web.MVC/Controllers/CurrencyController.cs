using Microsoft.AspNetCore.Mvc;
using AdventureWorks.NetCore.Repository.Models;
using Newtonsoft.Json;

namespace AdventureWorks.NetCore.Web.MVC.Controllers
{
    public class CurrencyController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Currency> currencyList = new List<Currency>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7156/Api/Currency"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    currencyList = JsonConvert.DeserializeObject<List<Currency>>(apiResponse);

                }
            }

            return View(currencyList);
        }

        public async Task<IActionResult> Details(string? id)
        {
            Currency currency = new Currency();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7156/api/Currency/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(apiResponse);
                        currency = currencies.First();

                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(currency);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Currency currency)
        {
            //Currency selectedCurrency = new Currency();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(currency), System.Text.Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7156/Api/Currency", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //selectedCurrency = JsonConvert.DeserializeObject<Currency>(apiResponse);
                }
                //ViewBag.Message = selectedCurrency;
            }
            return View();
        }
        public async Task<IActionResult> Delete(string? id)
        {
            Currency currency = new Currency();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7156/api/Currency/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(apiResponse);
                        currency = currencies.First();

                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }

            return View(currency);
        }
        public async Task<IActionResult> DeleteConfirmed(Currency cur)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7156/Api/Currency/" + cur.CurrencyCode))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }

            }
            return View();
        }
        public async Task<IActionResult> Edit(string? id)
        {
            return View();
        }
        public async Task<IActionResult> Edit(Currency cur)
        {

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(cur), System.Text.Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7156/Api/Currency", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }

            }
            return View();
        }



    
    }
}