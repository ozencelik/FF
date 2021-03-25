﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace Notification.Features.Alerts
{
    public class AlertService
    {
        private readonly ITempDataDictionary _tempData;

        public AlertService(IHttpContextAccessor contextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempData = tempDataDictionaryFactory.GetTempData(contextAccessor.HttpContext);
        }

        public void Success(string message, bool dismissable = true)
        {
            AddAlert(AlertType.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = true)
        {
            AddAlert(AlertType.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = true)
        {
            AddAlert(AlertType.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = true)
        {
            AddAlert(AlertType.Danger, message, dismissable);
        }

        private void AddAlert(string alertType, string message, bool dismissable)
        {
            // Get existing alerts
            var alerts = GetAlerts();

            // Add new alert
            alerts.Add(new Alert()
            {
                AlertType = alertType,
                Message = message,
                Dismissable = dismissable
            });

            // Save into the array
            _tempData[Alert.TempDataKey] = alerts;
        }

        public List<Alert> GetAlerts()
        {
            return _tempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)_tempData[Alert.TempDataKey]
                : new List<Alert>();
        }
    }
}
