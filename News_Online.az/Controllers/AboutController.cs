using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace News_Online.az.Controllers
{
    public class AboutController : Controller
    {
        AppDbContext db = new AppDbContext();
        public IActionResult Index()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }
    }
}
