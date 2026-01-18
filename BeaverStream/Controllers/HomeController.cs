using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeaverStream.Controllers
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
            _logger.LogInformation("Home page visited");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}