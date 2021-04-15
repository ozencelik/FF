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
using FF.Web.Extensions.Alerts;
using FF.Data.Models.SchoolBuses;
using System.Collections.Generic;
using FF.Data.Models.Classes;

namespace FF.Web.Controllers
{
    public class StudentController : Controller
    {
        #region Fields
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private readonly ISchoolService _schoolService;
        private readonly ISchoolBusService _schoolBusService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        private readonly AlertService _alertService;
        #endregion

        #region Ctor
        public StudentController(ILogger<StudentController> logger,
            IStudentService studentService,
            ISchoolService schoolService,
            ISchoolBusService schoolBusService,
            IClassService classService,
            IMapper mapper,
            AlertService alertService)
        {
            _logger = logger;
            _studentService = studentService;
            _schoolService = schoolService;
            _schoolBusService = schoolBusService;
            _classService = classService;
            _mapper = mapper;
            _alertService = alertService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createStudentModel = new CreateStudentModel()
            {
                SchoolBuses = _mapper.Map<IList<SchoolBusModel>>(await _schoolBusService.GetAllSchoolBusesAsync()),
                Classes = _mapper.Map<IList<ClassModel>>(await _classService.GetAllClassesAsync()),
            };

            return View(createStudentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateStudentModel model)
        {
            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(model);
                await _studentService.InsertStudentAsync(student);
                _alertService.Success("Yeni öğrenci başarılı bir şekilde kaydedildi.");
            }
            else
            {
                _alertService.Danger("Öğrenci kayıt işlemi sırasında hata oluştu !");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            var studentModel = _mapper.Map<UpdateStudentModel>(student);
            studentModel.SchoolBuses = _mapper.Map<IList<SchoolBusModel>>(await _schoolBusService.GetAllSchoolBusesAsync());
            studentModel.Classes = _mapper.Map<IList<ClassModel>>(await _classService.GetAllClassesAsync());

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
                _alertService.Success("Öğrenci güncelleme işlemi yapıldı.");
            }
            else
            {
                _alertService.Danger("Öğrenci güncelleme işlemi sırasında hata oluştu !");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            var studentModel = _mapper.Map<StudentModel>(student);
            return View(studentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string student_name)
        {
            if (ModelState.IsValid)
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                await _studentService.DeleteStudentAsync(student);
                _alertService.Success("Öğrenci silme işlemi yapıldı.");
            }
            else
            {
                _alertService.Danger("Öğrenci silme işlemi sırasında hata oluştu !");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var student = await _studentService.GetStudentByIdAsync(1);

            if (student is null)
                return RedirectToAction("ErrorPage", "Home");

            var studentModel = _mapper.Map<StudentModel>(student);
            return View(studentModel);
        }

        //[HttpGet]
        //public async Task<IActionResult> Profile(string profileAccessCode)
        //{
        //    if (string.IsNullOrEmpty(profileAccessCode))
        //        return RedirectToAction("ErrorPage", "Home");

        //    var student = await _studentService.GetStudentByProfileAccessCodeAsync(profileAccessCode);

        //    if (student is null)
        //        return RedirectToAction("ErrorPage", "Home");

        //    var studentModel = _mapper.Map<StudentModel>(student);
        //    return View(studentModel);
        //}

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
