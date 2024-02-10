using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimaWeb.Models;

namespace PrimaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Prenota()
    {
        return View( );
    }
    [HttpPost]
    public IActionResult Conferma(Prenotazione p)
    {
        return View(p);
    }
        
    [HttpGet]
    public IActionResult Form()
    {
        return View( );
    }

    public IActionResult SignUp()
    {
        return View( );
    }

    [HttpPost]
    public IActionResult Registra(SignUp s)
    {
        return View(s);
    }

    [HttpGet]
    public IActionResult Purchase()
    {
        return View( );
    }
    
    [HttpPost]
    public IActionResult Cart(Purchase C)
    {
        return View(C);
    }

    [HttpPost]
    public IActionResult AddToCart(Purchase purchase)
    {
        var purchaseController = new PurchaseController();
        return purchaseController.AddToCart(purchase);
    }

    

    

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
