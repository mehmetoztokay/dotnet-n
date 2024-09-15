using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Data;
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


        var productViewModel = new ProductViewModel()
        {
            Products = ProductRepository.Products
        };

        return View(productViewModel);

    }

    [Route("Product/Details/{itemid}")]
    public IActionResult Details(int itemid)
    {
        Product p = ProductRepository.GetProductById(itemid);
        return View(p);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
