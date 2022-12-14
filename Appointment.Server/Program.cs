global using Appointment.Data.Contexts;
global using Microsoft.EntityFrameworkCore;
global using System.Reflection;
global using Appointment.Data.Services;
global using Appointment.Data.Services.Interfaces;
global using Appointment.Data.Dtos;
global using Appointment.Data.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Doctor Appointment API";
    config.Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
});

builder.Services
    .AddDbContext<UserContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Dev"));
    })
    .AddDbContext<AppointmentContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Dev"));
    })
    .AddDbContext<EmployeeContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Dev"));
    })
    .AddTransient<IUserService, UserService>()
    .AddTransient<IEmployeeService, EmployeeService>()
    .AddTransient<IAppointmentService, AppointmentService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<AppSettingsDto>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi(); // serve OpenAPI/Swagger documents
    app.UseSwaggerUi3(c =>
    {
        c.CustomStylesheetPath = "/wwwroot/swagger-ui/DarkSwagger.css";
    });
    app.UseReDoc();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
