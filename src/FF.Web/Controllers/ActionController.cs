﻿using AutoMapper;
using FF.Core.Services.Actions;
using FF.Core.Services.Activities;
using FF.Core.Services.Students;
using FF.Data.Entities.Actions;
using FF.Data.Entities.Activities;
using FF.Data.Models.Actions;
using FF.Data.Models.Activities;
using FF.Data.Models.Students;
using FF.Web.Extensions.Alerts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Web.Controllers
{
    public class ActionController : Controller
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IActionService _actionService;
        private readonly IActivityService _activityService;
        private readonly AlertService _alertService;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Ctor
        public ActionController(IStudentService studentService,
            IActionService actionService,
            IActivityService activityService,
            AlertService alertService,
            IMapper mapper)
        {
            _studentService = studentService;
            _actionService = actionService;
            _activityService = activityService;
            _alertService = alertService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Create(int activityId)
        {
            // Get activity 
            var activity = await _activityService.GetActivityByIdAsync(activityId);

            if (activity == null)
            {
                _alertService.Danger("Aktivite bulunamadı !");
                return View();
            }

            var students = await _studentService.GetAllStudentsAsync();
            var action = new ActionModel()
            {
                ActivityId = activity.Id,
                Activity = _mapper.Map<ActivityModel>(activity),
                Students = _mapper.Map<IList<StudentModel>>(students),
            };

            return View(action);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ActionModel model)
        {
            var action = _mapper.Map<Action>(model);
            var studentActivities = _mapper.Map<IList<StudentActivity>>(model.StudentActivities);

            action.StudentActivities = studentActivities;

            await _actionService.InsertActionAsync(action);

            action.Activity = await _activityService.GetActivityByIdAsync(action.ActivityId);
            _alertService.Success($"{action.Activity.Name} başarılı bir şekilde kaydedildi ✓");

            return await Create(action.ActivityId);
        }
        #endregion
    }
}
