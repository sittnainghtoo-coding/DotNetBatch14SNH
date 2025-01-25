//using Microsoft.AspNetCore.Mvc;
//using Session.MVC.Models;
//using System.Diagnostics;

//namespace Session.MVC.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult
//        Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    // Action to set a session value
    public IActionResult SetSession()
    {
        HttpContext.Session.SetString("Username", "JohnDoe");
        return Content("Session value set!");
    }

    // Action to retrieve a session value
    public IActionResult GetSession()
    {
        var username = HttpContext.Session.GetString("Username");
        if (string.IsNullOrEmpty(username))
        {
            return Content("No session value found.");
        }
        return Content($"Hello, {username}!");
    }
}