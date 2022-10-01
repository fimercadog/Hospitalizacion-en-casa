using Microsoft.AspNetCore.Authentication.Cookies;
using PROYECTO_ROL_63.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
    option.LoginPath = "/AccesoController/Index";//especificar nuestr apagina de logeo 
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);//expiracion. tiempo de la duracin de las cookies
    //option.AccessDeniedPath = "/Home/Privacy";//acesso denegado. a donde ir cuando no tenga acceso 
    option.AccessDeniedPath = "/Home/Contact";//acesso denegado. a donde ir cuando no tenga acceso 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");

app.Run();


