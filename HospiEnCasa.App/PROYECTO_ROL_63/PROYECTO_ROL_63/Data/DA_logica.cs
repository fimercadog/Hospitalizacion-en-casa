using PROYECTO_ROL_63.Models;

namespace PROYECTO_ROL_63.Data
{
    public class DA_logica
    {

        public List<Usuario> ListaUsuario()
        {
            return new List<Usuario>
                {
                    new Usuario{Nombre="Jose",Correo="administrador@gmail.com",Clave="123",Roles=new string[]{ "Administrador" } },
                    new Usuario{Nombre="Fidel",Correo="fidel@gmail.com",Clave="123",Roles=new string[]{ "Empleado" } },
                    new Usuario{Nombre="Maria",Correo="Maria@gmail.com",Clave="123",Roles=new string[]{ "Supervisor" } },
                    new Usuario{Nombre="Fede",Correo="Fede@gmail.com",Clave="123",Roles=new string[]{ "Supervisor" } }
                };
        }


        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            return ListaUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();
        }

    }
}

