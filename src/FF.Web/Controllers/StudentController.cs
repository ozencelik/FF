using AutoMapper;
using FF.Core.Services.Students;
using FF.Data.Entities.Students;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using FF.Data.Models.Students;

namespace FF.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(ILogger<StudentController> logger,
            IStudentService studentService, IMapper mapper)
        {
            _logger = logger;
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();

            return View(students);
        }


        [HttpGet]
        public ActionResult StudentCreate()
        {
            return View("StudentCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentCreate([FromForm] StudentModel model)
        {
            if (ModelState.IsValid)
            {  
            var student = _mapper.Map<Student>(model);

                await _studentService.InsertStudentAsync(student);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> StudentUpdate(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            var studentModel = _mapper.Map<StudentModel>(student);
            return View("StudentUpdate", studentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentUpdate(int id, [FromForm] StudentModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;
                var student = _mapper.Map<Student>(model);
                await _studentService.UpdateStudentAsync(student);
            }
            return RedirectToAction(nameof(Index));
        }

        //İki kez almak ve ordan oraya çevirip durmak çok gereksiz oldu. Silme işlemi yalnızca id ve student modeli üzerinden form tarafında halledilebilir.
        [HttpGet]
        public async Task<ActionResult> StudentDelete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            var studentModel = _mapper.Map<StudentModel>(student);
            return View("StudentDelete", studentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentDelete(int id, string student_name)
        {
            if (ModelState.IsValid)
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                await _studentService.DeleteStudentAsync(student);
            }
            return RedirectToAction(nameof(Index));
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
