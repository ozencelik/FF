using AutoMapper;
using FF.Core.Services.Activities;
using FF.Core.Services.Students;
using FF.Data.Entities.StudentActivities;
using FF.Data.Enums.MealAmounts;
using FF.Data.Models.Activity;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Activity = System.Diagnostics.Activity;

namespace FF.Web.Controllers
{
    public class ActivityController : Controller
    {
        #region Fields
        private readonly ILogger<ActivityController> _logger;
        private readonly IStudentService _studentService;
        private readonly IMealActivityService _mealActivityService;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Ctor
        public ActivityController(ILogger<ActivityController> logger,
            IStudentService studentService,
            IMealActivityService mealActivityService,
            IMapper mapper)
        {
            _logger = logger;
            _studentService = studentService;
            _mealActivityService = mealActivityService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> MealActivity()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var getMealActivity = new MealActivityModel
            {
                Students = students,
                MealAmounts = Enum
                                .GetValues(typeof(MealAmount))
                                .OfType<MealAmount>()
                                .ToList()
            };

            return View(getMealActivity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MealActivity([FromForm] MealActivityModel model)
        {
            var mealActivities = _mapper.Map<IList<Meal>>(model.Activities);

            foreach (var mealActivity in mealActivities)
                await _mealActivityService.InsertMealActivityAsync(mealActivity);

            return await MealActivity();
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
