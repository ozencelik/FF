using Microsoft.AspNetCore.Mvc;

namespace FF.Web.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
