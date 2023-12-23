using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace News_Online.az.Controllers
{
    public class AdminController : Controller
    {
        AppDbContext db = new AppDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category()
        {
            var values = db.Categories.ToList();
            return View(values);
        }

        public IActionResult News()
        {
            var values = db.News.ToList();
            return View(values);
        }
    }
}
