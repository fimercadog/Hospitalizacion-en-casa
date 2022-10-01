using HospiEnCasa.Models;

namespace HospiEnCasa.Data
{
    public class DA_Logica
    {

        public List<Usuario> ListaUsuario()
        {
            return new List<Usuario>
                {
                    new Usuario{Nombre="Jose",Correo="administrador@gmail.com",Clave="123",Roles=new string[]{ "Administrador" } },
                    new Usuario{Nombre="Fidel",Correo="fidel@gmail.com",Clave="123",Roles=new string[]{ "Medico" } },
                    new Usuario{Nombre="Maria",Correo="Maria@gmail.com",Clave="123",Roles=new string[]{ "Enfermera" } },
                    new Usuario{Nombre="Fede",Correo="Fede@gmail.com",Clave="123",Roles=new string[]{ "Auxiliar" } }
                };
        }


        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            return ListaUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();
        }

    }
}

