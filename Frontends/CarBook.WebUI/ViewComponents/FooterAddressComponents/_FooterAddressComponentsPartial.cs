using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.FooterAddressDto;

namespace CarBook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentsPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/FooterAddress");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}

//Yüklediğiniz görseldeki kod, bir ASP.NET Core uygulamasında bir ViewComponent'i tanımlıyor. Bu ViewComponent'in amacı, bir API'den veri çekmek ve bu veriyi bir görünümde (view) göstermek.