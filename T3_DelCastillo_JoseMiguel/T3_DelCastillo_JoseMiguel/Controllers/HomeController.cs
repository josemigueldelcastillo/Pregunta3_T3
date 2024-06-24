using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using T3_DelCastillo_JoseMiguel.Models;


namespace T3_DelCastillo_JoseMiguel.Controllers
{
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
        public IActionResult LibroArquitectura()
        {
            return View();
        }
        public IActionResult LibroDiseño()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
