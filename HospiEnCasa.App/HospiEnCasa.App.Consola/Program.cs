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
    private static IReposotorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
    private static IReposotorioSugerenciaCuidado _repoSugerenciaCuidado = new RepositorioSugerenciaCuidado(new Persistencia.AppContext());
    private static IReposotorioSignoVital _repoSignoVital = new RepositorioSignoVital(new Persistencia.AppContext());
    static void Main(string[] args)
    {
      Console.WriteLine("Hello, World! EF");
      // paciente
      AddPaciente();
      BuscarPaciente(1);
      BuscarTodosPaciente();
      // TODO:REVISAR METODO
      // BorrarPaciente(13);


      // Enfermera
      AddEnfermera();
      BuscarEnfermera(1);
      BuscarTodasEnfermera();

      // Medico
      AddMedico();
      BuscarMedico(1);
      BuscarTodosMedico();

      // FamiliarDesignado
      AddFamiliarDesignado();
      BuscarFamiliarDesignado(1);
      BuscarTodosFamiliarDesignado();

      // Historia
      AddHistoria();
      BuscarHistoria(1);
      BuscarTodasHistorias();

      // SugerenciaCuidado
      AddSugerenciaCuidado();
      BuscarSugerenciaCuidado(1);
      BuscarTodasSugerenciaCuidados();

      // SignoVital
      AddSignoVital();
      BuscarSignoVital(1);
      BuscarTodasSignoVitales();



    }

    // Paciente
    private static void AddPaciente()
    {
      var paciente = new Paciente
      {
        Nombre = "prueba",
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


    // Historia
    private static void AddHistoria()
    {
      var Historia = new Historia
      {
        Diagnostico = "Dolor de ecabeza ",
        Entorno = "persona de 25 años",

      };
      _repoHistoria.AddHistoria(Historia);
    }


    private static void BuscarHistoria(int idHistoria)
    {
      var Historia = _repoHistoria.GetHistoria(idHistoria);
      Console.WriteLine("Historia: " + Historia.Diagnostico + " " + Historia.Entorno);
    }

    private static void BuscarTodasHistorias()
    {
      var Historias = _repoHistoria.GetAllHistorias();
      foreach (var Historia in Historias)
      {
        Console.WriteLine("Historia: " + Historia.Diagnostico + " " + Historia.Entorno);
      }
    }

    // SugerenciaCuidado
    private static void AddSugerenciaCuidado()
    {
      var SugerenciaCuidado = new SugerenciaCuidado
      {
        FechaHora = new DateTime(2033, 08, 30),
        Descripcion = "persona de 25 años con perros",

      };
      _repoSugerenciaCuidado.AddSugerenciaCuidado(SugerenciaCuidado);
    }


    private static void BuscarSugerenciaCuidado(int idSugerenciaCuidado)
    {
      var SugerenciaCuidado = _repoSugerenciaCuidado.GetSugerenciaCuidado(idSugerenciaCuidado);
      Console.WriteLine("SugerenciaCuidado: " + SugerenciaCuidado.FechaHora + " " + SugerenciaCuidado.Descripcion);
    }

    private static void BuscarTodasSugerenciaCuidados()
    {
      var SugerenciaCuidados = _repoSugerenciaCuidado.GetAllSugerenciaCuidados();
      foreach (var SugerenciaCuidado in SugerenciaCuidados)
      {
        Console.WriteLine("SugerenciaCuidado: " + SugerenciaCuidado.FechaHora + " " + SugerenciaCuidado.Descripcion);
      }
    }

    // SignoVital
    private static void AddSignoVital()
    {
      var SignoVital = new SignoVital
      {
        FechaHora = new DateTime(1975, 07, 12),
        TipoSigno = TipoSigno.Bueno

      };
      _repoSignoVital.AddSignoVital(SignoVital);
    }



    private static void BuscarSignoVital(int idSignoVital)
    {
      var SignoVital = _repoSignoVital.GetSignoVital(idSignoVital);
      Console.WriteLine("SignoVital: " + SignoVital.FechaHora + " " + SignoVital.TipoSigno);
    }

    private static void BuscarTodasSignoVitales()
    {
      var SignosVitales = _repoSignoVital.GetAllSignosVitales();
      foreach (var SignoVital in SignosVitales)
      {
        Console.WriteLine("SignoVital: " + SignoVital.FechaHora + " " + SignoVital.TipoSigno);
      }
    }

  }
}
