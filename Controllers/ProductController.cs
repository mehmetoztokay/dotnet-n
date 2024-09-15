using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int clock = DateTime.Now.Hour;
        ViewBag.Greeting = clock > 12 ? "Gunaydinlar" : "Iyi Gunler";
        ViewBag.User = "Mehmet";

        return View();
    }

    public IActionResult List()
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

    public IActionResult Details()
    {
        Product p = new Product() { Name = "Samsung S6", Price = 3000, Description = "Fena degil" };
        return View(p);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
