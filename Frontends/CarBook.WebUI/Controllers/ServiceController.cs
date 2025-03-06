using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
			ViewBag.v1 = "Servicess";
			ViewBag.v2 = "Our Servicess";
			return View();
        }
    }
}
