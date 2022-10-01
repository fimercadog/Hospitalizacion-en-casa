using HospiEnCasa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace HospiEnCasa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles = "Administrador,Medico,Enfermera")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrador,Enfermera")]
        public IActionResult Enfermera()
        {
            return View();
        }
        [Authorize(Roles = "Administrador,Enfermera")]
        public IActionResult FamiliaresDesignadoes()
        {
            return View();
        }
        [Authorize(Roles = "Administrador,Medico,Enfermera")]
        public IActionResult Historias()
        {
            return View();
        }
        [Authorize(Roles = "Administrador,Medico")]
        public IActionResult Medicos()
        {
            return View();
        }
        [Authorize(Roles = "Administrador,Medico,Enfermera")]
        public IActionResult Pacientes()
        {
            return View();
        }
        [Authorize(Roles = "Administrador,Medico,Enfermera")]
        public IActionResult SignosVitales()
        {
            return View();
        }
        [Authorize(Roles = "Administrador,Medico,Enfermera")]
        public IActionResult SugerenciasCuidadoes()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}