using Microsoft.AspNetCore.Mvc;
using HospiEnCasa.Models;
using HospiEnCasa.Data;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace HospiEnCasa.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario) //Viene la el objeto de usuario con correo y contraseña
        {
            DA_Logica _da_usuario = new DA_Logica(); //Crea instancia de DA_Logica

            var usuario = _da_usuario.ValidarUsuario(_usuario.Correo, _usuario.Clave); //Ejecuta ValidarUsuario
            if (usuario != null) //Usuario diferente al vacio
            {
                //Crear cookies de autorizacion del usuario
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("Correo", usuario.Correo)
                };

                //Añadir rol del usuario
                //Recorrer cada uno de los roles
                foreach (string rol in usuario.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //Crear toda la cookie en la sesion de logeo
                //Pasar el esquema creado al esquema predefinido

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                return RedirectToAction("Index", "Home"); //Redirecciona a Home
            }
            else
            {
                return View();
            }
        }

        //Redireccionar Index pero del controlador Acceso
        public async Task<IActionResult> Salir() //Simular el formulario inicio de sesion
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }

    }
}