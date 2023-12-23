using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace News_Online.az.Controllers
{
    public class CategoryController : Controller
    {
        AppDbContext db=new AppDbContext();
        public IActionResult Index()
        {
            var values = db.Categories.ToList();
            return View(values);
        }
    }
}
