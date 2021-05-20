using AutoMapper;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using FF.Data.Models.Students;
using FF.Core.Services.SchoolBuses;
using FF.Core.Services.Schools;

namespace FF.Web.Controllers
{
    public class SchoolController : Controller
    {
        #region Fields
        private readonly ILogger<SchoolController> _logger;
        private readonly ISchoolBusService _schoolBusService;
        private readonly ISchoolService _schoolService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public SchoolController(ILogger<SchoolController> logger,
            ISchoolBusService schoolBusService,
            ISchoolService schoolService,
            IMapper mapper)
        {
            _logger = logger;
            _schoolBusService = schoolBusService;
            _schoolService = schoolService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var dashboardModel = await _schoolService.GetDashboardCardsCount();
            dashboardModel.ActivitiesPageLink = Url.Action("Index", "Acitiviy");
            dashboardModel.ClassesPageLink = Url.Action("Index", "Class");
            dashboardModel.TeachersPageLink = Url.Action("Index", "Teacher");
            dashboardModel.StudentsPageLink = Url.Action("Index", "Student");
            dashboardModel.SchoolBusesPageLink = Url.Action("Index", "SchoolBus");

            return View(dashboardModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _schoolBusService.GetAllSchoolBusesAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateStudentModel model)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateStudentModel model)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string student_name)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string profileAccessCode)
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
