global using Appointment.Client;
global using Appointment.Client.Services.Interfaces;
global using Appointment.Client.Services;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["apiUrl"]!;

builder.Services
    .AddScoped(sp => new HttpClient
    {
        BaseAddress = new Uri(apiUrl)
    })
    .AddScoped<IAccountService, AccountService>()
    .AddScoped<IEmployeeService, EmployeeService>()
    .AddScoped<IAppointmentService, AppointmentService>()
    .AddScoped<IAlertService, AlertService>()
    .AddScoped<IHttpService, HttpService>()
    .AddScoped<ILocalStorageService, LocalStorageService>()
    .AddScoped<DialogService>()
    .AddScoped<NotificationService>()
    .AddScoped<TooltipService>()
    .AddScoped<ContextMenuService>();

var host = builder.Build();

var accountService = host.Services.GetRequiredService<IAccountService>();
await accountService.Initialize();

await host.RunAsync();
