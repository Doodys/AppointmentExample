global using DoctorAppointment.Client;
global using DoctorAppointment.Client.Services.Interfaces;
global using DoctorAppointment.Client.Services;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["apiUrl"]!;

builder.Services
    .AddScoped(sp => new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7216/")
    })
    .AddScoped<IAccountService, AccountService>()
    .AddScoped<IEmployeeService, EmployeeService>()
    .AddScoped<IAlertService, AlertService>()
    .AddScoped<IHttpService, HttpService>()
    .AddScoped<ILocalStorageService, LocalStorageService>();

var host = builder.Build();

var accountService = host.Services.GetRequiredService<IAccountService>();
await accountService.Initialize();

await host.RunAsync();
