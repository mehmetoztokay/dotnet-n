using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var products = new List<Product>() {
            new Product {Name = "Iphone 8",  Price = 3000, Description="Harika"},
            new Product {Name = "Iphone X",  Price = 6000, Description="Muko"},
        };

        // var categories = new List<Category>(){
        //     new Category() { Name = "Telefonlar", Description = "Telefon kategorisi" },
        //     new Category() { Name = "Bilgisayar", Description = "Bilgisayar kategorisi" },
        //     new Category() { Name = "Elektronik", Description = "Elektronik kategorisi" },
        // };


        var productViewModel = new ProductViewModel()
        {
            // Categories = categories,
            Products = products
        };

        return View(productViewModel);

    }

    public IActionResult About()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
