// See https://aka.ms/new-console-template for more information
using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
  class Program
  {
    private static IReposotorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
    private static IReposotorioEnfermera _repoEnfermera = new RepositorioEnfermera(new Persistencia.AppContext());
    static void Main(string[] args)
    {
      Console.WriteLine("Hello, World! EF");
      AddPaciente();
      BuscarPaciente(1);
      // Enfermera
      AddEnfermera();
      BuscarEnfermera(1);
    }

    private static void AddPaciente()
    {
      var paciente = new Paciente
      {
        Nombre = "Fidel",
        Apellidos = "Mercado",
        NumeroTelefono = "739247598",
        Genero = Genero.Masculino,
        Direccion = "Calle 1 Suba",
        Latitud = 4.745232195624607F,
        Longitud = -74.0896484884421F,
        Ciudad = "Manizales",
        FechaNacimiento = new DateTime(1975, 07, 12)
      };
      _repoPaciente.AddPaciente(paciente);
    }


    private static void BuscarPaciente(int idPaciente)
    {
      var paciente = _repoPaciente.GetPaciente(idPaciente);
      Console.WriteLine("Paciente: " + paciente.Nombre + " " + paciente.Apellidos);
    }

    private static void AddEnfermera()
    {
      var Enfermera = new Enfermera
      {
        Nombre = "Eliana",
        Apellidos = "Rodriguez",
        NumeroTelefono = "739247598",
        Genero = Genero.Femenino,

        TarjetaProfesional = "12345678",
        horas_laboradas = 20,

      };
      _repoEnfermera.AddEnfermera(Enfermera);
    }


    private static void BuscarEnfermera(int idEnfermera)
    {
      var Enfermera = _repoEnfermera.GetEnfermera(idEnfermera);
      Console.WriteLine("Enfermera: " + Enfermera.Nombre + " " + Enfermera.Apellidos);
    }

  }
}
