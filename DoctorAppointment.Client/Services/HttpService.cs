using DoctorAppointment.Client.Helpers;
using DoctorAppointment.Client.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace DoctorAppointment.Client.Services;

public class HttpService : IHttpService
{
    private HttpClient _httpClient;

    public HttpService(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> Get<T>(string uri)
    {
        var result = await _httpClient.GetAsync(uri);
        await ValidateResponse(result);
        return await ReadFromContent<T>(result);
    }

    public async Task Post(string uri, object value)
    {
        var content = SerializeContent(value);
        var result = await _httpClient.PostAsync(uri, content);
        await ValidateResponse(result);
    }

    public async Task<T> Post<T>(string uri, object value)
    {
        var content = SerializeContent(value);
        var result = await _httpClient.PostAsync(uri, content);
        await ValidateResponse(result);
        return await ReadFromContent<T>(result);
    }

    public async Task Put(string uri, object value)
    {
        var content = SerializeContent(value);
        var result = await _httpClient.PutAsync(uri, content);
        await ValidateResponse(result);
    }

    public async Task<T> Put<T>(string uri, object value)
    {
        var content = SerializeContent(value);
        var result = await _httpClient.PutAsync(uri, content);
        await ValidateResponse(result);
        return await ReadFromContent<T>(result);
    }

    public async Task Delete(string uri)
    {
        var result = await _httpClient.DeleteAsync(uri);
        await ValidateResponse(result);
    }

    // helper methods

    private StringContent SerializeContent(object value = null)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Empty content");
        }

        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return new StringContent(JsonSerializer.Serialize(value, serializeOptions), Encoding.UTF8, "application/json");
    }

    private async Task<T> ReadFromContent<T>(HttpResponseMessage response)
    {
        var options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;
        options.Converters.Add(new StringConverter());
        return await response.Content.ReadFromJsonAsync<T>(options);
    }

    private async Task ValidateResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadFromJsonAsync<ErrorModel>();
            throw new Exception(errorContent!.Message);
        }
    }
}