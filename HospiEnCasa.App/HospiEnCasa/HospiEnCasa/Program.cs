using HospiEnCasa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
  option.LoginPath = "/AccesoController/Index";//especificar nuestr apagina de logeo 
  option.ExpireTimeSpan = TimeSpan.FromMinutes(20);//expiracion. tiempo de la duracin de las cookies
                                                   //option.AccessDeniedPath = "/Home/Privacy";//acesso denegado. a donde ir cuando no tenga acceso 
  option.AccessDeniedPath = "/Home/Contact";//acesso denegado. a donde ir cuando no tenga acceso 
});


IServiceCollection serviceCollection = builder.Services.AddDbContext<HospiEnCasaDataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");

app.Run();
