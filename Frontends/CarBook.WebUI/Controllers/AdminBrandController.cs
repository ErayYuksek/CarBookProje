using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BrandDtos;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.FeatureDtos;

namespace CarBook.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5216/api/Brand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5216/api/Brand", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index"); // Yönlendirme işlemi sonrası
            }
            return View(); // Başarısızsa aynı sayfada kal
        }


        public async Task<IActionResult> RemoveBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5216/api/Brand?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
       
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // 🚗 API'den markaları çek
            var brandResponse = await client.GetAsync("http://localhost:5216/api/Brand");
            if (brandResponse.IsSuccessStatusCode)
            {
                var jsonData = await brandResponse.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                    ViewBag.Brands = new SelectList(values, "BrandID", "Name");
                }
                else
                {
                    ViewBag.Brands = new SelectList(new List<ResultBrandDto>(), "BrandID", "Name");
                }
            }
            else
            {
                ViewBag.Brands = new SelectList(new List<ResultBrandDto>(), "BrandID", "Name");
            }

            // 🚗 API'den araba verisini çek
            var responseMessage = await client.GetAsync($"http://localhost:5216/api/Car/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonCarData = await responseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(jsonCarData))
                {
                    var carValues = JsonConvert.DeserializeObject<UpdateCarDto>(jsonCarData);
                    return View(carValues);
                }
            }

            ModelState.AddModelError("", "Araba bilgileri alınamadı.");
            return View(new UpdateCarDto()); // Boş bir model döndür
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            if (updateBrandDto == null)
            {
                ModelState.AddModelError("", "Gönderilen veri geçersiz.");
                return View(updateBrandDto);
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("http://localhost:5216/api/Brand", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // API çağrısı başarısızsa hata mesajı göster
            ModelState.AddModelError("", "Güncelleme başarısız oldu. Lütfen tekrar deneyin.");
            return View(updateBrandDto);
        }

    }
}
