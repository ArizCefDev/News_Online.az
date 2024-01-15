using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace News_Online.az.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();
        public IActionResult Index(string search)
        {
            var values = db.News.ToList();
            //var values = from s in db.News.ToList() select s;
            //if (!string.IsNullOrEmpty(search))
            //{
            //    values = values.Where(x => x.Title.Contains(search.ToLower()));
            //}

            //var movies = from m in db.News
            //             select m;

            //if (!String.IsNullOrEmpty(search))
            //{
            //    movies = movies.Where(s => s.Title!.Contains(search));
            //}

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
