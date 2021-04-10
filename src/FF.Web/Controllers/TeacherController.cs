using AutoMapper;
using FF.Data.Entities.Students;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using FF.Data.Models.Students;
using FF.Core.Services.Classes;
using FF.Core.Services.Teachers;
using FF.Core.Services.Activities;
using FF.Data.Models.Teachers;
using FF.Data.Models.Activities;
using System.Collections.Generic;

namespace FF.Web.Controllers
{
    public class TeacherController : Controller
    {
        #region Fields
        private readonly ILogger<TeacherController> _logger;
        private readonly IActivityService _activityService;
        private readonly ITeacherService _teacherService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public TeacherController(ILogger<TeacherController> logger,
            IActivityService activityService,
            ITeacherService teacherService,
            IClassService classService,
            IMapper mapper)
        {
            _logger = logger;
            _activityService = activityService;
            _teacherService = teacherService;
            _classService = classService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(1);

            if (teacher is null)
                return RedirectToAction("ErrorPage");

            // Get schoolBus acitivities (except schoolBus activity)
            var homeModel = new HomeModel()
            {
                Teacher = _mapper.Map<TeacherModel>(teacher),
                Activities = _mapper.Map<IList<ActivityModel>>(await _activityService.GetTeacherActivitiesAsync())
            };

            return View(homeModel);
        }

        //[HttpGet]
        //public async Task<IActionResult> Home(string accessCode)
        //{
        //    if (string.IsNullOrEmpty(accessCode))
        //        return RedirectToAction("ErrorPage", "Home");

        //    var teacher = await _teacherService.GetTeacherByAccessCodeAsync(accessCode);

        //    if (teacher is null)
        //        return RedirectToAction("ErrorPage");

        //    // Get schoolBus acitivities (except schoolBus activity)
        //    var homeModel = new HomeModel()
        //    {
        //        Teacher = _mapper.Map<TeacherModel>(teacher),
        //        Activities = _mapper.Map<IList<ActivityModel>>(await _activityService.GetTeacherActivitiesAsync())
        //    };

        //    return View(homeModel);
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _teacherService.GetAllTeachersAsync();

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
