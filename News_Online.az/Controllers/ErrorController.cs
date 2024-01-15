using Microsoft.AspNetCore.Mvc;

namespace News_Online.az.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
