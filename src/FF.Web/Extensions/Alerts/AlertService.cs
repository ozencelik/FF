using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FF.Web.Extensions.Alerts
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
            AddAlert(AlertType.Success, string.Concat("<strong>✔️ Başarılı </strong> ", message), dismissable);
        }

        public void Information(string message, bool dismissable = true)
        {
            AddAlert(AlertType.Information, string.Concat("<strong>ℹ️ Bilgilendirme</strong> ", message), dismissable);
        }

        public void Warning(string message, bool dismissable = true)
        {
            AddAlert(AlertType.Warning, string.Concat("<strong>⚡ Uyarı</strong> ", message), dismissable);
        }

        public void Danger(string message, bool dismissable = true)
        {
            AddAlert(AlertType.Danger, string.Concat("<strong>❌ Hata</strong> ", message), dismissable);
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
            _tempData[Alert.TempDataKey] = JsonConvert.SerializeObject(alerts);
        }

        public List<Alert> GetAlerts()
        {
            return _tempData.ContainsKey(Alert.TempDataKey)
                ? JsonConvert.DeserializeObject<List<Alert>>(_tempData[Alert.TempDataKey].ToString())
                : new List<Alert>();
        }

        public void DeleteAlerts()
        {
            _tempData[Alert.TempDataKey] = JsonConvert.SerializeObject(new List<Alert>());
        }
    }
}
