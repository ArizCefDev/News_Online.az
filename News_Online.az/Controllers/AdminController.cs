using DataAccess.Context;
using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace News_Online.az.Controllers
{
    public class AdminController : Controller
    {
        AppDbContext db = new AppDbContext();

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

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

        public IActionResult About()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }

        //About Add
        [HttpGet]
        public IActionResult AboutAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutAdd(About p)
        {
            db.Abouts.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "About");
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
            var values = db.Categories.Find(id);
            db.Categories.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Category");
        }


        //News Add
        [HttpGet]
        public IActionResult NewsAdd()
        {
            IEnumerable<SelectListItem> valueGet = (from x in db.Categories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;

            return View();
        }

        [HttpPost]
        public IActionResult NewsAdd(New p, IFormFile photo)
        {
            Random rnd = new Random();
            int rnumber = rnd.Next(1, 1000);

            //Kateqoriyani getirmek

            IEnumerable<SelectListItem> valueGet = (from x in db.Categories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;


            //sekil secmek - upload
            if (photo == null || photo.Length == 0)
            {
                return Content("Sekil secilmedi");
            }
            else
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "newsimg", photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                photo.CopyToAsync(stream);
                p.Image = photo.FileName;
            }
            p.Date = DateTime.Now;
            p.View = rnumber;
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

        public IActionResult AboutDelete(int id)
        {
            var values = db.Abouts.Find(id);
            db.Abouts.Remove(values);
            db.SaveChanges();
            return RedirectToAction("About");
        }
    }
}
