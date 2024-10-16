using Microsoft.AspNetCore.Mvc;
using shopapp.data.Abstract;
using shopapp.webui.Data;
using shopapp.webui.Models;
using System.Diagnostics;

namespace shopapp.webui.Controllers;

public class HomeController : Controller
{
    // Bu iki kod parcacagi arasinda
    private IProductRepository _productRepository;
    public HomeController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    // Dependency Injection yapmis olduk
    // Simdi otomatik olarak gelecek ancak bos su anda bunu cozmek icin 
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var productViewModel = new ProductViewModel()
        {
            Products = ProductRepository.Products
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