using DAL.Interfaces;
using DAL;
using BLL.Interfaces;
using BLL;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "Sample of .NET 6 with Angular app template",
        Contact = new OpenApiContact
        {
            Name = "Quentin FERRER",
            Email = "ferrerquentin@hotmail.com"
        },
        License = new OpenApiLicense
        {
            Name = "Open License"
           
        }
    });
});
#region Register Dependencies
builder.Services.AddSingleton<IWeatherForecastDAL, WeatherForecastDAL>();
builder.Services.AddSingleton<IWeatherForecastBLL, WeatherForecastBLL>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
