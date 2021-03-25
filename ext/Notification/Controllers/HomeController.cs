using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notification.Features.Alerts;
using Notification.Models;
using System.Diagnostics;

namespace Notification.Controllers
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
