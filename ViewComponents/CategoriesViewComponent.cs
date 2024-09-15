using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Models;

namespace shopapp.webui.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new List<Category>()
            {
            new Category() { Name = "Telefonlar", Description = "Telefon kategorisi" },
            new Category() { Name = "Bilgisayar", Description = "Bilgisayar kategorisi" },
            new Category() { Name = "Elektronik", Description = "Elektronik kategorisi" },
            };

            return View(categories);

        }
    }
}