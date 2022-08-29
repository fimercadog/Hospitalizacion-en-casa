using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioMedico : IReposotorioMedico
  {

    private readonly AppContext _appContext;

    public RepositorioMedico(AppContext appContext)
    {
      _appContext = appContext;
    }

    Medico IReposotorioMedico.AddMedico(Medico Medico)
    {
      var MedicoAdiocnado = _appContext.Medicos.Add(Medico);
      _appContext.SaveChanges();
      return MedicoAdiocnado.Entity;
    }

    void IReposotorioMedico.DeleteMedico(int idMedico)
    {
      var MedicoEncontrada = _appContext.Medicos.FirstOrDefault(p => p.Id == idMedico);
      if (MedicoEncontrada ==null)
      {
        return;
      }
      _appContext.Medicos.Remove(MedicoEncontrada);
      _appContext.SaveChanges();
    }

    IEnumerable<Medico> IReposotorioMedico.GetAllMedicos()
    {
      return _appContext.Medicos;
    }

    Medico IReposotorioMedico.GetMedico(int idMedico)
    {
      return _appContext.Medicos.FirstOrDefault(p => p.Id == idMedico);

    }

    Medico IReposotorioMedico.UpdateMedico(Medico Medico)
    {
      var MedicoEncontrada = _appContext.Medicos.FirstOrDefault(p => p.Id == Medico.Id);
      if (MedicoEncontrada!=null)
      {
        MedicoEncontrada.Nombre = Medico.Nombre;
        MedicoEncontrada.Apellidos = Medico.Apellidos;
        MedicoEncontrada.NumeroTelefono = Medico.NumeroTelefono;
        MedicoEncontrada.Genero = Medico.Genero;

        MedicoEncontrada.Especialidad = Medico.Especialidad;
        MedicoEncontrada.Codigo = Medico.Codigo;
        MedicoEncontrada.RegistroRethus = Medico.RegistroRethus;

        _appContext.SaveChanges();
      }
      return MedicoEncontrada;
    }
  }
}