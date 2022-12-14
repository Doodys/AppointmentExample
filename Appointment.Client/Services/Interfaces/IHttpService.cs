namespace Appointment.Client.Services.Interfaces;

public interface IHttpService
{
    Task Post(string uri, object value);
    Task Put(string uri, object value);
    Task Delete(string uri);
    Task<T> Post<T>(string uri, object value);
    Task<T> Put<T>(string uri, object value);
    Task<T> Get<T>(string uri);
}
