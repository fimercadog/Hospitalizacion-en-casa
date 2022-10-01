using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_ROL_63.Models;
using PROYECTO_ROL_63.Data;

namespace PROYECTO_ROL_63.Controllers
{

   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "Administrador,Supervisor,Empleado")]
        public IActionResult Index()
        {
            
            return View();
        }

        
        public IActionResult Ventas()
        {
            return View();
        }

        [Authorize(Roles = "Administrador,Supervisor")]
        public IActionResult Compras()
        {
            return View();
        }
        [Authorize(Roles = "Administrador,Supervisor")]
        public IActionResult Clientes()
        {
            return View();
        }


       // public IActionResult Privacy()
       // {

       //     return View();
       //}

        public IActionResult Contact()
        {

            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}