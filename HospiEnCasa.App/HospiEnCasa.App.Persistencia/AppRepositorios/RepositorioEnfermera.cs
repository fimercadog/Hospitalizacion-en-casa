using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioEnfermera : IReposotorioEnfermera
  {

    private readonly AppContext _appContext;

    public RepositorioEnfermera(AppContext appContext)
    {
      _appContext = appContext;
    }

    Enfermera IReposotorioEnfermera.AddEnfermera(Enfermera Enfermera)
    {
      var EnfermeraAdiocnado = _appContext.Enfermeras.Add(Enfermera);
      _appContext.SaveChanges();
      return EnfermeraAdiocnado.Entity;
    }

    void IReposotorioEnfermera.DeleteEnfermera(int idEnfermera)
    {
      var EnfermeraEncontrada = _appContext.Enfermeras.FirstOrDefault(p => p.Id == idEnfermera);
      if (EnfermeraEncontrada ==null)
      {
        return;
      }
      _appContext.Enfermeras.Remove(EnfermeraEncontrada);
      _appContext.SaveChanges();
    }

    IEnumerable<Enfermera> IReposotorioEnfermera.GetAllEnfermeras()
    {
      return _appContext.Enfermeras;
    }

    Enfermera IReposotorioEnfermera.GetEnfermera(int idEnfermera)
    {
      return _appContext.Enfermeras.FirstOrDefault(p => p.Id == idEnfermera);

    }

    Enfermera IReposotorioEnfermera.UpdateEnfermera(Enfermera Enfermera)
    {
      var EnfermeraEncontrada = _appContext.Enfermeras.FirstOrDefault(p => p.Id == Enfermera.Id);
      if (EnfermeraEncontrada!=null)
      {
        EnfermeraEncontrada.Nombre = Enfermera.Nombre;
        EnfermeraEncontrada.Apellidos = Enfermera.Apellidos;
        EnfermeraEncontrada.NumeroTelefono = Enfermera.NumeroTelefono;
        EnfermeraEncontrada.Genero = Enfermera.Genero;

        EnfermeraEncontrada.TarjetaProfesional = Enfermera.TarjetaProfesional;
        EnfermeraEncontrada.horas_laboradas = Enfermera.horas_laboradas;

        _appContext.SaveChanges();
      }
      return EnfermeraEncontrada;
    }
  }
}