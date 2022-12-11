using DoctorAppointment.Client.Helpers;
using DoctorAppointment.Client.Models;
using DoctorAppointment.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace DoctorAppointment.Client.Services;

public class HttpService : IHttpService
{
    private HttpClient _httpClient;
    private NavigationManager _navigationManager;
    private ILocalStorageService _localStorageService;
    private IConfiguration _configuration;

    public HttpService(
        HttpClient httpClient,
        NavigationManager navigationManager,
        ILocalStorageService localStorageService,
        IConfiguration configuration
    )
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
        _configuration = configuration;
    }

    public async Task<T> Get<T>(string uri)
    {
        var result = await _httpClient.GetAsync(uri);
        return await ReadFromContent<T>(result);
    }

    public async Task Post(string uri, object value)
    {
        var content = SerializeContent(value);
        var result = await _httpClient.PostAsync(uri, content);
    }

    public async Task<T> Post<T>(string uri, object value)
    {
        var content = SerializeContent(value);
        var result = await _httpClient.PostAsync(uri, content);
        return await ReadFromContent<T>(result);
    }

    public async Task Put(string uri, object value)
    {
        var content = SerializeContent(value);
        var result = await _httpClient.PutAsync(uri, content);
    }

    public async Task<T> Put<T>(string uri, object value)
    {
        var content = SerializeContent(value);
        var result = await _httpClient.PutAsync(uri, content);
        return await ReadFromContent<T>(result);
    }

    public async Task Delete(string uri)
    {
        var result = await _httpClient.DeleteAsync(uri);
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
}