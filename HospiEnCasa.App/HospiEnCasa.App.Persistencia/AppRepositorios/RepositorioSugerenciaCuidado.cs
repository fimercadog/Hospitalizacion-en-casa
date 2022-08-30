using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioSugerenciaCuidado : IReposotorioSugerenciaCuidado
  {

    private readonly AppContext _appContext;

    public RepositorioSugerenciaCuidado(AppContext appContext)
    {
      _appContext = appContext;
    }

    SugerenciaCuidado IReposotorioSugerenciaCuidado.AddSugerenciaCuidado(SugerenciaCuidado SugerenciaCuidado)
    {
      var SugerenciaCuidadoAdiocnado = _appContext.SugerenciasCuidado.Add(SugerenciaCuidado);
      _appContext.SaveChanges();
      return SugerenciaCuidadoAdiocnado.Entity;
    }

    void IReposotorioSugerenciaCuidado.DeleteSugerenciaCuidado(int idSugerenciaCuidado)
    {
      var SugerenciaCuidadoEncontrada = _appContext.SugerenciasCuidado.FirstOrDefault(p => p.Id == idSugerenciaCuidado);
      if (SugerenciaCuidadoEncontrada ==null)
      {
        return;
      }
      _appContext.SugerenciasCuidado.Remove(SugerenciaCuidadoEncontrada);
      _appContext.SaveChanges();
    }

    IEnumerable<SugerenciaCuidado> IReposotorioSugerenciaCuidado.GetAllSugerenciaCuidados()
    {
      return _appContext.SugerenciasCuidado;
    }

    SugerenciaCuidado IReposotorioSugerenciaCuidado.GetSugerenciaCuidado(int idSugerenciaCuidado)
    {
      return _appContext.SugerenciasCuidado.FirstOrDefault(p => p.Id == idSugerenciaCuidado);

    }

    SugerenciaCuidado IReposotorioSugerenciaCuidado.UpdateSugerenciaCuidado(SugerenciaCuidado SugerenciaCuidado)
    {
      var SugerenciaCuidadoEncontrada = _appContext.SugerenciasCuidado.FirstOrDefault(p => p.Id == SugerenciaCuidado.Id);
      if (SugerenciaCuidadoEncontrada!=null)
      {

        SugerenciaCuidadoEncontrada.FechaHora = SugerenciaCuidado.FechaHora;
        SugerenciaCuidadoEncontrada.Descripcion = SugerenciaCuidado.Descripcion;

        _appContext.SaveChanges();
      }
      return SugerenciaCuidadoEncontrada;
    }
  }
}