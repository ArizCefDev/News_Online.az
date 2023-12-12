using Microsoft.AspNetCore.Mvc;

namespace News_Online.az.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
