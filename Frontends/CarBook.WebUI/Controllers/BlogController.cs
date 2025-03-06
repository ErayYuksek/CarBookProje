using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CarPricingDtos;

namespace CarBook.WebUI.Controllers
{
	public class BlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Blogs";
            ViewBag.v2 = "Blogs of our authors";
         
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Blog/GetAllBlogWithAuthorQueryResult");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }

            return View();
        }


        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Blogs";
            ViewBag.v2 = "Blogs Detail and Comment";
            ViewBag.BlogId = id;
            return View();

        }
    }
}
