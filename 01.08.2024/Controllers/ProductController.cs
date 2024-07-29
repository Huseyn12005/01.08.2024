using _01._08._2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01._08._2024.Controllers;

public class ProductController : Controller
{
    private static List<Product> products = new List<Product>();
    public IActionResult Index()
    {
        return View(products);
    }

    public IActionResult GetProductById(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        return View(product);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        if(products.Count > 0) product.Id = products.Max(p=> p.Id) + 1;
        else product.Id = 1;
        products.Add(product);
        return View("Index",products);
    }

    public IActionResult Remove(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        products.Remove(product);
        return View("Index",products);
    }

    public IActionResult GetProductsByPrice(decimal price)
    {
        var _products = products.Where(p=>p.Price == price).ToList();
        return View(_products);
    }
}
