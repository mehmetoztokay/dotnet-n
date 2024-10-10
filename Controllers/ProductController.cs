using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopapp.webui.Data;
using shopapp.webui.Models;
using System.Diagnostics;

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

        return View(new Product());
        // Diyelim ki create sayfasini actik orada eger product.name'i bulamazsa sorun olur o yuzden bos bir product yolladik
    }

    [HttpPost]
    [Route("product/create")]
    public IActionResult Create(Product p)
    {
        if (ModelState.IsValid)
        // ModelState ile olusturulan obj'nin tamamiyla valid oldugunu kontrol edebiliyoruz.
        {
            ProductRepository.AddProduct(p);
            return RedirectToAction("list");

        }
        return View(p);

    }

    [HttpGet]
    [Route("product/edit")]
    public IActionResult Edit(int id)
    {
        ViewBag.Categories = new SelectList(CategoryRepository.Categories, "Categories");

        return View(ProductRepository.GetProductById(id));

    }

    [HttpPost]
    [Route("product/edit")]
    public IActionResult Edit(Product p)
    {
        ProductRepository.EditProduct(p);
        return RedirectToAction("list");

    }

    [HttpPost]
    public IActionResult Delete(Product p)
    {
        ProductRepository.DeleteProduct(p);
        return RedirectToAction("list");

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
