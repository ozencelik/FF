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

namespace FF.Web.Controllers
{
    public class TeacherController : Controller
    {
        #region Fields
        private readonly ILogger<TeacherController> _logger;
        private readonly ITeacherService _teacherService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public TeacherController(ILogger<TeacherController> logger,
            ITeacherService teacherService,
            IClassService classService,
            IMapper mapper)
        {
            _logger = logger;
            _teacherService = teacherService;
            _classService = classService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            // 
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _teacherService.GetAllTeachersAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createStudentModel = new CreateStudentModel()
            {
                SchoolBuses = await _schoolBusService.GetAllSchoolBusesAsync(),
                Classes = await _classService.GetAllClasssAsync(),
            };

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateStudentModel model)
        {
            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(model);
                await _studentService.InsertStudentAsync(student);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            var studentModel = _mapper.Map<UpdateStudentModel>(student);
            studentModel.SchoolBuses = await _schoolBusService.GetAllSchoolBusesAsync();
            studentModel.Classes = await _classService.GetAllClasssAsync();

            return View(studentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateStudentModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedStudent = await _studentService.GetStudentByIdAsync(id);
                updatedStudent = _mapper.Map<Student>(model);

                await _studentService.UpdateStudentAsync(updatedStudent);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            var studentModel = _mapper.Map<StudentModel>(student);
            return View("Delete", studentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string student_name)
        {
            if (ModelState.IsValid)
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                await _studentService.DeleteStudentAsync(student);
            }
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
