using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Alert.Features.Alerts;
using Alert.Models;
using System.Diagnostics;

namespace Alert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AlertService _alertService;

        public HomeController(ILogger<HomeController> logger,
            AlertService alertService)
        {
            _logger = logger;
            _alertService = alertService;
        }

        public IActionResult Index()
        {
            _alertService.Success("Deneme success");
            return View();
        }

        public IActionResult Privacy()
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
