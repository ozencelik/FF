using AutoMapper;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using FF.Core.Services.SchoolBuses;
using FF.Core.Services.Activities;
using FF.Data.Models.SchoolBuses;
using FF.Data.Models.Activities;
using System.Collections.Generic;
using FF.Data.Entities.SchoolBuses;
using FF.Web.Extensions.Alerts;

namespace FF.Web.Controllers
{
    public class SchoolBusController : Controller
    {
        #region Fields
        private readonly ILogger<SchoolBusController> _logger;
        private readonly IActivityService _activityService;
        private readonly ISchoolBusService _schoolBusService;
        private readonly IMapper _mapper;
        private readonly AlertService _alertService;
        #endregion

        #region Ctor
        public SchoolBusController(ILogger<SchoolBusController> logger,
            IActivityService activityService,
            ISchoolBusService schoolBusService,
            IMapper mapper,
            AlertService alertService)
        {
            _logger = logger;
            _activityService = activityService;
            _schoolBusService = schoolBusService;
            _mapper = mapper;
            _alertService = alertService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var schoolBus = await _schoolBusService.GetSchoolBusByIdAsync(1);

            if (schoolBus is null)
                return RedirectToAction("ErrorPage");

            // Get schoolBus acitivities (except schoolBus activity)
            var homeModel = new HomeModel()
            {
                SchoolBus = _mapper.Map<SchoolBusModel>(schoolBus),
                Activities = _mapper.Map<IList<ActivityModel>>(await _activityService.GetSchoolBusActivitiesAsync())
            };

            return View(homeModel);
        }

        //[HttpGet]
        //public async Task<IActionResult> Home(string accessCode)
        //{
        //    if (string.IsNullOrEmpty(accessCode))
        //        return RedirectToAction("ErrorPage", "Home");

        //    var schoolBus = await _schoolBusService.GetSchoolBusByAccessCodeAsync(accessCode);

        //    if (schoolBus is null)
        //        return RedirectToAction("ErrorPage");

        //    // Get schoolBus acitivities (except schoolBus activity)
        //    var homeModel = new HomeModel()
        //    {
        //        SchoolBus = _mapper.Map<SchoolBusModel>(schoolBus),
        //        Activities = _mapper.Map<IList<ActivityModel>>(await _activityService.GetSchoolBusActivitiesAsync())
        //    };

        //    return View(homeModel);
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _schoolBusService.GetAllSchoolBusesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index1()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CreateSchoolBusModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateSchoolBusModel model)
        {
            if (ModelState.IsValid)
            {
                var schoolBus = _mapper.Map<SchoolBus>(model);
                schoolBus.SchoolId = 1;
                await _schoolBusService.InsertSchoolBusAsync(schoolBus);
                _alertService.Success("Yeni servis başarılı bir şekilde kaydedildi.");
            }
            else
            {
                _alertService.Danger("Servis kayıt işlemi sırasında hata oluştu !");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var schoolBus = await _schoolBusService.GetSchoolBusByIdAsync(id);
            var schoolBusModel = _mapper.Map<UpdateSchoolBusModel>(schoolBus);

            return View(schoolBusModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateSchoolBusModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedSchoolBus = await _schoolBusService.GetSchoolBusByIdAsync(id);
                updatedSchoolBus = _mapper.Map<SchoolBus>(model);

                await _schoolBusService.UpdateSchoolBusAsync(updatedSchoolBus);
                _alertService.Success("Servis güncelleme işlemi yapıldı.");
            }
            else
            {
                _alertService.Danger("Servis güncelleme işlemi sırasında hata oluştu !");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var schoolBus = await _schoolBusService.GetSchoolBusByIdAsync(id);
            var schoolBusModel = _mapper.Map<SchoolBusModel>(schoolBus);

            return View(schoolBusModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string school_bus_name)
        {
            if (ModelState.IsValid)
            {
                var teacher = await _schoolBusService.GetSchoolBusByIdAsync(id);
                await _schoolBusService.DeleteSchoolBusAsync(teacher);
                _alertService.Success("Servis silme işlemi yapıldı.");
            }
            else
            {
                _alertService.Danger("Servis silme işlemi sırasında hata oluştu !");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail()
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
