using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace News_Online.az.ViewsComponents.Category
{
    public class CategoryList:ViewComponent
    {
        AppDbContext db=new AppDbContext();
        public IViewComponentResult Invoke()
        {
            var values = db.Categories.ToList();
            return View(values);
        }
    }
}
