using Microsoft.AspNetCore.Mvc;
using shopapp.business.Concrete;
using shopapp.data.Abstract;
using shopapp.webui.Models;
using System.Diagnostics;

namespace shopapp.webui.Controllers;

public class HomeController : Controller
{
    // Bu iki kod parcacagi arasinda
    private IProductService _productService;
    public HomeController(IProductService productService)
    {
        this._productService = productService;
    }
    // Dependency Injection yapmis olduk
    // Simdi otomatik olarak gelecek ancak bos su anda bunu cozmek icin 
    private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public IActionResult Index()
    {
        var productViewModel = new ProductViewModel()
        {
            Products = _productService.GetAll()
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