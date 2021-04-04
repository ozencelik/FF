using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FF.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly ILogger<StudentController> _logger;
        #endregion

        #region Ctor
        public HomeController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            return RedirectToAction("Home", "School");
        }

        public IActionResult ErrorPage()
        {
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
        #endregion
    }
}
