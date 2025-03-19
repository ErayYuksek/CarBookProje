using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogsDetailRecentBlogsComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogsDetailRecentBlogsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5216/api/Blog/"+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultLast3BlogsWithAuthors>(jsonData); // Doğru model deserialize
                return View(values); // Modeli Razor View'e gönder
            }

            return View(); // API başarısız olursa boş liste döndür
        }
    }
}
