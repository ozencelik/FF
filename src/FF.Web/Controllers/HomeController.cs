using AutoMapper;
using FF.Core.Services.Students;
using FF.Data.Entities.Students;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using FF.Data.Models.Students;
using FF.Core.Services.Classes;
using FF.Core.Services.Schools;
using FF.Core.Services.SchoolBuses;

namespace FF.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private readonly ISchoolService _schoolService;
        private readonly ISchoolBusService _schoolBusService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public HomeController(ILogger<StudentController> logger,
            IStudentService studentService,
            ISchoolService schoolService,
            ISchoolBusService schoolBusService,
            IClassService classService,
            IMapper mapper)
        {
            _logger = logger;
            _studentService = studentService;
            _schoolService = schoolService;
            _schoolBusService = schoolBusService;
            _classService = classService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Index(string code)
        {
            if (string.IsNullOrEmpty(code))
                return RedirectToAction("Home", "School");

            return RedirectToAction("Detail", "Student", new { profileAccessCode = code });
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
