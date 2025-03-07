using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BrandDtos;
using UdemyCarBook.Dto.CarDtos;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Car/GetCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {

                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDtos>>(JsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7000/api/Brand");

                if (!responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("API Hatası: " + responseMessage.StatusCode);
                    return StatusCode(500, "API isteği başarısız oldu: " + responseMessage.StatusCode);
                }

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

                if (values == null || !values.Any())
                {
                    Console.WriteLine("API'den gelen veri boş!");
                    return StatusCode(500, "API'den gelen veri boş!");
                }

                List<SelectListItem> brands = values.Select(x => new SelectListItem
                {
                    Text = x.BrandName,
                    Value = x.BrandID.ToString()
                }).ToList();

                ViewBag.BrandValues = brands;
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA: " + ex.Message);
                return StatusCode(500, "Hata oluştu: " + ex.Message);
            }


        }



    }
}