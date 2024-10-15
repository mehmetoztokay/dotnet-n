using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Data;

namespace shopapp.webui.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["action"].ToString() == "List")
            {
                ViewBag.SelectedCategory = RouteData?.Values["itemid"];
            }

            var categories = CategoryRepository.Categories;

            return View(categories);
        }
    }
}