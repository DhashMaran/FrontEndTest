using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FrontEndTest.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace FrontEndTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IActionResult> Index()
        {
            
            var client = _httpClientFactory.CreateClient();

            // Make a GET request to the API endpoint to fetch items
            var items = await client.GetFromJsonAsync<List<Item>>("https://localhost:7104/api/Order/items");

            
            return View(items);
        }

        
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] List<int> itemIds)
        {
            
            var client = _httpClientFactory.CreateClient();

            // Make a POST request to the API endpoint to place the order
            var response = await client.PostAsJsonAsync("https://localhost:7104/api/Order/placeorder", itemIds);

            // Checks if the request is successful
            if (response.IsSuccessStatusCode)
            {
                
                var result = await response.Content.ReadFromJsonAsync<List<Package>>();

                
                return Json(result);
            }
            else
            {
               
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        // error handling
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
