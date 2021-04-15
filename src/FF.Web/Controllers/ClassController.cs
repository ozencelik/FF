using AutoMapper;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using FF.Core.Services.Classes;
using FF.Web.Extensions.Alerts;
using FF.Data.Models.Classes;
using FF.Data.Entities.Classes;
using FF.Core.Services.Teachers;
using FF.Data.Models.Teachers;
using System.Collections.Generic;

namespace FF.Web.Controllers
{
    public class ClassController : Controller
    {
        #region Fields
        private readonly ILogger<ClassController> _logger;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        private readonly AlertService _alertService;
        private readonly ITeacherService _teacherService;
        #endregion

        #region Ctor
        public ClassController(ILogger<ClassController> logger,
            IClassService classService,
            IMapper mapper,
            AlertService alertService,
            ITeacherService teacherService)
        {
            _logger = logger;
            _classService = classService;
            _mapper = mapper;
            _alertService = alertService;
            _teacherService = teacherService;
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
            var students = await _classService.GetAllClassesAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createClassModel = new CreateClassModel()
            {
                Teachers = _mapper.Map<IList<TeacherModel>>(await _teacherService.GetAllTeachersAsync())
            };

            return View(createClassModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateClassModel model)
        {
            if (ModelState.IsValid)
            {
                var classroom = _mapper.Map<Class>(model);
                classroom.SchoolId = 1;
                await _classService.InsertClassAsync(classroom);
                _alertService.Success("Yeni sınıf başarılı bir şekilde kaydedildi.");
            }
            else
            {
                _alertService.Danger("Sınıf kayıt işlemi sırasında hata oluştu !");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var classroom = await _classService.GetClassByIdAsync(id);
            var classroomModel = _mapper.Map<UpdateClassModel>(classroom);
            classroomModel.Teachers = _mapper.Map<IList<TeacherModel>>(await _teacherService.GetAllTeachersAsync());

            return View(classroomModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateClassModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedClass = await _classService.GetClassByIdAsync(id);
                updatedClass.Name = model.Name;
                updatedClass.TeacherId = model.TeacherId;

                await _classService.UpdateClassAsync(updatedClass);
                _alertService.Success("Sınıf güncelleme işlemi yapıldı.");
            }
            else
            {
                _alertService.Danger("Sınıf güncelleme işlemi sırasında hata oluştu !");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var classroom = await _classService.GetClassByIdAsync(id);
            var classroomModel = _mapper.Map<ClassModel>(classroom);
            return View(classroomModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string class_name)
        {
            if (ModelState.IsValid)
            {
                var classroom = await _classService.GetClassByIdAsync(id);
                await _classService.DeleteClassAsync(classroom);
                _alertService.Success("Sınıf silme işlemi yapıldı.");
            }
            else
            {
                _alertService.Danger("Sınıfa silme işlemi sırasında hata oluştu !");
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
