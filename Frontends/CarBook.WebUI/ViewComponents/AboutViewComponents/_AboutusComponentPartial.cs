using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AboutDtos;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutusComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutusComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/About");
            //var responseMessage = await client.GetAsync("https://localhost:7000/api/About\r\n");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject < List<ResultAboutDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
