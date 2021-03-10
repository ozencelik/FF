using FF.Core.Services.Students;
using FF.Data.Enums.MealAmounts;
using FF.Web.Models;
using FF.Web.Models.Activity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Web.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly IStudentService _studentService;

        public ActivityController(ILogger<ActivityController> logger,
            IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        public async Task<IActionResult> MealActivity()
        {
            var students = await _studentService.GetAllStudentsAsync();

            var createMealActivity = students.Select(s => new CreateMealActivityModel()
            {
                Student = s,
                MealAmount = MealAmount.NeverEaten
            }).ToList();

            return View(createMealActivity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MealActivity([FromBody] List<CreateMealActivityModel> model)
        {
            var students = await _studentService.GetAllStudentsAsync();

            return View(students);
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
    }
}
