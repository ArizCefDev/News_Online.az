using DataAccess.Context;
using DataAccess.Entity;
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

        //Category Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category p)
        {
            db.Categories.Add(p);
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        //Category Delete

        public IActionResult Delete(int id)
        {
            var values=db.Categories.Find(id);
            db.Categories.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Category");
        }


        //News Add
        [HttpGet]
        public IActionResult NewsAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewsAdd(New p)
        {
            p.Date = DateTime.Now;
            db.News.Add(p);
            db.SaveChanges();
            return RedirectToAction("News");
        }

        //News Delete

        public IActionResult NewsDelete(int id)
        {
            var values = db.News.Find(id);
            db.News.Remove(values);
            db.SaveChanges();
            return RedirectToAction("News");
        }
    }
}
