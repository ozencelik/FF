using AutoMapper;
using FF.Core.Services.Activities;
using FF.Data.Models.Activities;
using FF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Web.Controllers
{
    public class ActivityController : Controller
    {
        #region Fields
        private readonly ILogger<ActivityController> _logger;
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Ctor
        public ActivityController(ILogger<ActivityController> logger,
            IActivityService activityService,
            IMapper mapper)
        {
            _logger = logger;
            _activityService = activityService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Get all acitivities
            var activities = await _activityService.GetAllActivitiesAsync();

            return View(_mapper.Map<IList<ActivityModel>>(activities));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
