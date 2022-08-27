using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioPaciente : IReposotorioPaciente
  {

    private readonly AppContext _appContext;

    public RepositorioPaciente(AppContext appContext)
    {
      _appContext = appContext;
    }

    Paciente IReposotorioPaciente.AddPaciente(Paciente paciente)
    {
      var pacienteAdiocnado = _appContext.Pacientes.Add(paciente);
      _appContext.SaveChanges();
      return pacienteAdiocnado.Entity;
    }

    void IReposotorioPaciente.DeletePaciente(int idPaciente)
    {
      var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
      if (pacienteEncontrado ==null)
      {
        return;
      }
      _appContext.Pacientes.Remove(pacienteEncontrado);
      _appContext.SaveChanges();
    }

    IEnumerable<Paciente> IReposotorioPaciente.GetAllPacientes()
    {
      return _appContext.Pacientes;
    }

    Paciente IReposotorioPaciente.GetPaciente(int idPaciente)
    {
      return _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);

    }

    Paciente IReposotorioPaciente.UpdatePaciente(Paciente paciente)
    {
      var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
      if (pacienteEncontrado!=null)
      {
        pacienteEncontrado.Nombre = paciente.Nombre;
        pacienteEncontrado.Apellidos = paciente.Apellidos;
        pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
        pacienteEncontrado.Genero = paciente.Genero;
        pacienteEncontrado.Direccion = paciente.Direccion;
        pacienteEncontrado.Latitud = paciente.Latitud;
        pacienteEncontrado.Longitud = paciente.Longitud;
        pacienteEncontrado.Ciudad = paciente.Ciudad;
        pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
        pacienteEncontrado.Familiar = paciente.Familiar;
        pacienteEncontrado.Enfermera = paciente.Enfermera;
        pacienteEncontrado.Medico = paciente.Medico;
        pacienteEncontrado.Historia = paciente.Historia;

        _appContext.SaveChanges();
      }
      return pacienteEncontrado;
    }
  }
}