using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.PricingDtos;

namespace CarBook.WebUI.Controllers
{
    public class AdminPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5216/api/Pricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreatePricing()
        {
            return View("~/Views/AdminPricing/CreatePricing.cshtml");
        }


        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPricingDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5216/api/Pricing", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing");
            }
            return View(); // Başarısızsa aynı sayfada kal
        }


        public async Task<IActionResult> RemovePricing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5216/api/Pricing?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdatePricing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5216/api/Pricing/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdatePricingDto>(jsonData);
                return View(value);
            }
            return View();

        }



        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatebannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatebannerDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5216/api/Pricing", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
