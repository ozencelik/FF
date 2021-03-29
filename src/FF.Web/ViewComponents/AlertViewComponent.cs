using Microsoft.AspNetCore.Mvc;
using FF.Web.Extensions.Alerts;
using System.Threading.Tasks;

namespace FF.Web.ViewComponents
{
    public class AlertViewComponent : ViewComponent
    {
        private readonly AlertService _alertService;

        public AlertViewComponent(AlertService alertService)
        {
            _alertService = alertService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var alerts = _alertService.GetAlerts();
            _alertService.DeleteAlerts();

            return await Task.FromResult((IViewComponentResult)View(alerts));
        }
    }
}
