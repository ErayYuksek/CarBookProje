using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.TestimonialDtos;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Car/GetLast5CarsWithBrandQueryHandler");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandsDtos>>(jsonData);
                return View(values);
            }

            return View();
        }

    }
}

//Bu kodun genel amacı, son 5 arabayı ve onların markalarını temsil eden bir API'den veri çekmek ve bu veriyi bir View'da göstermek. Örneğin, bir web sitesinde "Son Eklenen Arabalar" gibi bir bölümde bu ViewComponent kullanılabilir.