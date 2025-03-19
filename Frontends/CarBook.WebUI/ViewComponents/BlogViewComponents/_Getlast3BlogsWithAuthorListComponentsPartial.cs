using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using UdemyCarBook.Dto.BlogDtos;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _Getlast3BlogsWithAuthorListComponentsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _Getlast3BlogsWithAuthorListComponentsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5216/api/Blog/GetLast3BlogsWithAuthorsList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthors>>(jsonData); // Doğru model deserialize
                return View(values); // Modeli Razor View'e gönder
            }

            return View(new List<ResultLast3BlogsWithAuthors>()); // API başarısız olursa boş liste döndür
        }
    }
}

//Bu kod, View Component kullanarak bir API'den veri çekmek ve bu veriyi Razor View'e (HTML çıktısı) göndermek için kullanılıyor. Özetle, dinamik olarak dışarıdan veri alıp sayfada göstermenizi sağlıyor.