namespace Notification.Features.Alerts
{
    public class Alert
    {
        public const string TempDataKey = "TempDataAlert";

        public string AlertType { get; set; }

        public string Message { get; set; }

        public bool Dismissable { get; set; }
    }

    public static class AlertType
    {
        public const string Success = "success";

        public const string Information = "info";

        public const string Warning = "warning";

        public const string Danger = "danger";
    }
}
