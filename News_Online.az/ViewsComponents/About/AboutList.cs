using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace News_Online.az.ViewsComponents.About
{
    public class AboutList : ViewComponent
    {
        AppDbContext db = new AppDbContext();
        public IViewComponentResult Invoke()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }
    }
}
