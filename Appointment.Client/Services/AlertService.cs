using Appointment.Client.Models;
using Appointment.Client.Services.Interfaces;

namespace Appointment.Client.Services;

public class AlertService : IAlertService
{
    private const string _defaultId = "default-alert";
    public event Action<Alert> OnAlert;

    public void Success(string message, bool keepAfterRouteChange = true, bool autoClose = false)
    {
        this.Alert(new Alert
        {
            Type = AlertType.Success,
            Message = message,
            KeepAfterRouteChange = keepAfterRouteChange,
            AutoClose = autoClose
        });
    }        

    public void Error(string message, bool keepAfterRouteChange = true, bool autoClose = false)
    {
        this.Alert(new Alert
        {
            Type = AlertType.Error,
            Message = message,
            KeepAfterRouteChange = keepAfterRouteChange,
            AutoClose = autoClose
        });
    }        

    public void Info(string message, bool keepAfterRouteChange = true, bool autoClose = false)
    {
        this.Alert(new Alert
        {
            Type = AlertType.Info,
            Message = message,
            KeepAfterRouteChange = keepAfterRouteChange,
            AutoClose = autoClose
        });
    }        

    public void Warn(string message, bool keepAfterRouteChange = true, bool autoClose = false)
    {
        this.Alert(new Alert
        {
            Type = AlertType.Warning,
            Message = message,
            KeepAfterRouteChange = keepAfterRouteChange,
            AutoClose = autoClose
        });
    }        

    public void Alert(Alert alert)
    {
        alert.Id = alert.Id ?? _defaultId;
        this.OnAlert?.Invoke(alert);
    }

    public void Clear(string id = _defaultId)
    {
        this.OnAlert?.Invoke(new Alert { Id = id });
    }
}