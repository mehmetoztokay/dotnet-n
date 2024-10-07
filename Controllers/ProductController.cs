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

    [Route("Product/List/{itemid?}")]
    public IActionResult List(int? itemid)
    {

        // 1. QueryString parametre olarak string? q dersek ornegin, altta direkt ulasabiliriz ama daha farkli yollari da var:
        // Console.WriteLine(q);

        // 2. Diger yol
        // Console.WriteLine(Request.Query["q"]);



        var products = ProductRepository.Products;

        var q = Request.Query["q"].ToString();

        if (!string.IsNullOrEmpty(q))
        {
            products = products.Where(p => p.Name.ToLower().Contains(q) || p.Description.ToLower().Contains(q)).ToList();
        }

        if (itemid != null)
        {
            products = products.Where(p => p.CategoryId == itemid).ToList();
        }

        var productViewModel = new ProductViewModel()
        {
            Products = products
        };

        return View(productViewModel);

    }

    [Route("Product/Details/{itemid}")]
    public IActionResult Details(int itemid)
    {

        Product p = ProductRepository.GetProductById(itemid);
        return View(p);

    }


    [HttpGet]
    [Route("product/create")] // Burada Route ile GET isteğini ayırdım
    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    [Route("product/create")]
    public IActionResult Create(Product p)
    {
        ProductRepository.AddProduct(p);
        return RedirectToAction("list");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
