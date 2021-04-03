using AutoMapper;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using FF.Data.Models.Students;
using FF.Core.Services.SchoolBuses;
using FF.Core.Services.Activities;
using FF.Data.Models.SchoolBuses;
using FF.Data.Models.Activities;
using System.Collections.Generic;

namespace FF.Web.Controllers
{
    public class SchoolBusController : Controller
    {
        #region Fields
        private readonly ILogger<SchoolBusController> _logger;
        private readonly IActivityService _activityService;
        private readonly ISchoolBusService _schoolBusService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public SchoolBusController(ILogger<SchoolBusController> logger,
            IActivityService activityService,
            ISchoolBusService schoolBusService,
            IMapper mapper)
        {
            _logger = logger;
            _activityService = activityService;
            _schoolBusService = schoolBusService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            // Get schoolBus acitivities (except schoolBus activity)
            var homeModel = new HomeModel()
            {
                Activities = _mapper.Map<IList<ActivityModel>>(await _activityService.GetSchoolBusActivitiesAsync())
            };

            return View(homeModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
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
