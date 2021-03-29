using Microsoft.AspNetCore.Mvc;

namespace FF.Web.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
