using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignBootstrap.Models;

namespace SignBootstrap.Controllers;

public class HomeController : Controller
{
    public readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private string isAuthenticated = "true";


    public IActionResult Index()
    {
        string? isAuthenticated = HttpContext.Session.GetString("isAuthenticated");
        return View();
    }

    public IActionResult Privacy()
    {
        string? isAuthenticated = HttpContext.Session.GetString("isAuthenticated");
        if (isAuthenticated == "OK")
            return View();
        return Redirect("\\home\\Login");
        
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
    public ActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(Login L)
    {
    // Verifica che le credenziali siano corrette
    if (L.Nome_Utente == "q" && L.Password == "q")
    {
        // Imposta isAuthenticated a true nella sessione
        HttpContext.Session.SetString("isAuthenticated", "OK");
        return RedirectToAction("IndexAuth"); // Reindirizza alla homepage
    }
    else
    {
         HttpContext.Session.SetString("isAuthenticated", "K.O");
        // Se le credenziali non sono corrette, mostra un messaggio di errore o reindirizza a una pagina di login fallito
        ViewBag.ErrorMessage = "Credenziali non valide. Riprova.";
        return View();
    }
    }

    [HttpGet]
    public IActionResult IndexAuth()
    {
        return View();
    }

    [HttpPost]
    public IActionResult IndexAuth(string isAuthenticated)
    {
        return View();
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
