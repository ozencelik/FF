using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FF.Web.Controllers
{
    public class TablesController : Controller
    {
        public IActionResult TableElements()
        {
            return View();
        }

        public IActionResult TablePlugins()
        {
            return View();
        }
    }
}
