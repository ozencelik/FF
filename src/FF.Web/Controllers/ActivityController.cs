using AutoMapper;
using FF.Core.Services.Activities;
using FF.Core.Services.Students;
using FF.Data.Entities.Activities;
using FF.Data.Models.Activity;
using FF.Data.Models.StudentModels;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activity = System.Diagnostics.Activity;

namespace FF.Web.Controllers
{
    public class ActivityController : Controller
    {
        #region Fields
        private readonly ILogger<ActivityController> _logger;
        private readonly IStudentService _studentService;
        private readonly IActivityService _activityService;
        private readonly IStudentActivityService _studentActivityService;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Ctor
        public ActivityController(ILogger<ActivityController> logger,
            IStudentService studentService,
            IActivityService activityService,
            IStudentActivityService studentActivityService,
            IMapper mapper)
        {
            _logger = logger;
            _studentService = studentService;
            _activityService = activityService;
            _studentActivityService = studentActivityService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Get Meal Activity
            var mealActivity = await _activityService.GetActivityByIdAsync(1);

            // Get all students.
            // TODO : In the future, students get by using their classes.
            // We do not need all students in the system.
            var students = await _studentService.GetAllStudentsAsync();

            var activity = _mapper.Map<ActivityModel>(mealActivity);
            activity.Students = _mapper.Map<IList<StudentModel>>(students);

            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateActivity([FromForm] ActivityModel model)
        {
            var studentActivities = _mapper.Map<IList<StudentActivity>>(model.StudentActivities);

            foreach (var activity in studentActivities)
                await _studentActivityService.InsertStudentActivityAsync(activity);

            return await Index();
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
