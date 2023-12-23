using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace News_Online.az.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();
        public IActionResult Index()
        {
            var values = db.News.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var values = db.News.Find(id);
            return View(values);
        }
    }
}
