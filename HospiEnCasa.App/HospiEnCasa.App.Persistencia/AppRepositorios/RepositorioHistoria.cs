using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioHistoria : IReposotorioHistoria
  {

    private readonly AppContext _appContext;

    public RepositorioHistoria(AppContext appContext)
    {
      _appContext = appContext;
    }

    Historia IReposotorioHistoria.AddHistoria(Historia Historia)
    {
      var HistoriaAdiocnado = _appContext.Historias.Add(Historia);
      _appContext.SaveChanges();
      return HistoriaAdiocnado.Entity;
    }

    void IReposotorioHistoria.DeleteHistoria(int idHistoria)
    {
      var HistoriaEncontrada = _appContext.Historias.FirstOrDefault(p => p.Id == idHistoria);
      if (HistoriaEncontrada == null)
      {
        return;
      }
      _appContext.Historias.Remove(HistoriaEncontrada);
      _appContext.SaveChanges();
    }

    IEnumerable<Historia> IReposotorioHistoria.GetAllHistorias()
    {
      return _appContext.Historias;
    }

    Historia IReposotorioHistoria.GetHistoria(int idHistoria)
    {
      return _appContext.Historias.FirstOrDefault(p => p.Id == idHistoria);

    }

    Historia IReposotorioHistoria.UpdateHistoria(Historia Historia)
    {
      var HistoriaEncontrada = _appContext.Historias.FirstOrDefault(p => p.Id == Historia.Id);
      if (HistoriaEncontrada != null)
      {

        HistoriaEncontrada.Diagnostico = Historia.Diagnostico;
        HistoriaEncontrada.Entorno = Historia.Entorno; 

        _appContext.SaveChanges();
      }
      return HistoriaEncontrada;
    }
  }
}