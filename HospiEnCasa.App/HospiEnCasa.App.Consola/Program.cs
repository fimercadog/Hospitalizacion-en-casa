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
    private static IReposotorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
    private static IReposotorioFamiliarDesignado _repoFamiliarDesignado = new RepositorioFamiliarDesignado(new Persistencia.AppContext());
    static void Main(string[] args)
    {
      Console.WriteLine("Hello, World! EF");
      // paciente
      BuscarTodosPaciente();
      AddPaciente();
      BuscarPaciente(1);
      // Enfermera
      BuscarTodasEnfermera();
      AddEnfermera();
      BuscarEnfermera(1);
      // Medico
      BuscarTodosMedico();
      AddMedico();
      BuscarMedico(1);

      // FamiliarDesignado
      BuscarTodosFamiliarDesignado();
      AddFamiliarDesignado();
      BuscarFamiliarDesignado(1);
    }

    // Paciente
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

    private static void BuscarTodosPaciente()
    {
      var pacientes = _repoPaciente.GetAllPacientes();
      foreach (var paciente in pacientes)
      {
        Console.WriteLine("Paciente: " + paciente.Nombre + " " + paciente.Apellidos);
      }
    }

    // Enfermera
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

    private static void BuscarTodasEnfermera()
    {
      var Enfermeras = _repoEnfermera.GetAllEnfermeras();
      foreach (var Enfermera in Enfermeras)
      {
        Console.WriteLine("Enfermera: " + Enfermera.Nombre + " " + Enfermera.Apellidos);
      }
    }

    // Medico
    private static void AddMedico()
    {
      var Medico = new Medico
      {
        Nombre = "Federico",
        Apellidos = "Gutierrez",
        NumeroTelefono = "739247598",
        Genero = Genero.Masculino,

        Especialidad = "General",
        Codigo = "172893787",
        RegistroRethus = "078754385",

      };
      _repoMedico.AddMedico(Medico);
    }


    private static void BuscarMedico(int idMedico)
    {
      var Medico = _repoMedico.GetMedico(idMedico);
      Console.WriteLine("Medico: " + Medico.Nombre + " " + Medico.Apellidos);
    }

    private static void BuscarTodosMedico()
    {
      var Medicos = _repoMedico.GetAllMedicos();
      foreach (var Medico in Medicos)
      {
        Console.WriteLine("Medico: " + Medico.Nombre + " " + Medico.Apellidos);
      }
    }

    // FamiliarDesignado
    private static void AddFamiliarDesignado()
    {
      var FamiliarDesignado = new FamiliarDesignado
      {
        Nombre = "Nancy",
        Apellidos = "García",
        NumeroTelefono = "739247598",
        Genero = Genero.Masculino,

        Parentesco = "Hermana",
        Correo = "nancy@gmail.com"

      };
      _repoFamiliarDesignado.AddFamiliarDesignado(FamiliarDesignado);
    }


    private static void BuscarFamiliarDesignado(int idFamiliarDesignado)
    {
      var FamiliarDesignado = _repoFamiliarDesignado.GetFamiliarDesignado(idFamiliarDesignado);
      Console.WriteLine("FamiliarDesignado: " + FamiliarDesignado.Nombre + " " + FamiliarDesignado.Apellidos);
    }

    private static void BuscarTodosFamiliarDesignado()
    {
      var FamiliarDesignados = _repoFamiliarDesignado.GetAllFamiliaresDesignados();
      foreach (var FamiliarDesignado in FamiliarDesignados)
      {
        Console.WriteLine("FamiliarDesignado: " + FamiliarDesignado.Nombre + " " + FamiliarDesignado.Apellidos);
      }
    }


  }
}
