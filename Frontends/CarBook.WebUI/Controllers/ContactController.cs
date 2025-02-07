using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.ContactDtos;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {

            var client = _httpClientFactory.CreateClient();
            createContactDto.SendDate = DateTime.Now;

            var JsonData = JsonConvert.SerializeObject(createContactDto);

            StringContent stringcontent = new StringContent(JsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7000/api/Contact", stringcontent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }

        //Kodun Amacı:
        //Kullanıcıdan alınan bir CreateContactDto nesnesini JSON formatında seri hale getiriyor.
        //Bu JSON verisini bir HTTP POST isteği ile bir API'ye gönderiyor.
        //Eğer API'den başarılı bir yanıt alırsa, başka bir sayfaya (örneğin Index action'ı) yönlendiriyor.
        //Eğer hata oluşursa, mevcut view'a geri dönüyor.

    }
}
