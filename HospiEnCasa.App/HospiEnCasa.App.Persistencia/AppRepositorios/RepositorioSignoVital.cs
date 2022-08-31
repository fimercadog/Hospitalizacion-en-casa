using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioSignoVital : IReposotorioSignoVital
  {

    private readonly AppContext _appContext;

    public RepositorioSignoVital(AppContext appContext)
    {
      _appContext = appContext;
    }

    SignoVital IReposotorioSignoVital.AddSignoVital(SignoVital SignoVital)
    {
      var SignoVitalAdiocnado = _appContext.SignosVitales.Add(SignoVital);
      _appContext.SaveChanges();
      return SignoVitalAdiocnado.Entity;
    }

    void IReposotorioSignoVital.DeleteSignoVital(int idSignoVital)
    {
      var SignoVitalEncontrada = _appContext.SignosVitales.FirstOrDefault(p => p.Id == idSignoVital);
      if (SignoVitalEncontrada ==null)
      {
        return;
      }
      _appContext.SignosVitales.Remove(SignoVitalEncontrada);
      _appContext.SaveChanges();
    }

    IEnumerable<SignoVital> IReposotorioSignoVital.GetAllSignosVitales()
    {
      return _appContext.SignosVitales;
    }

    SignoVital IReposotorioSignoVital.GetSignoVital(int idSignoVital)
    {
      return _appContext.SignosVitales.FirstOrDefault(p => p.Id == idSignoVital);

    }

    SignoVital IReposotorioSignoVital.UpdateSignoVital(SignoVital SignoVital)
    {
      var SignoVitalEncontrado = _appContext.SignosVitales.FirstOrDefault(p => p.Id == SignoVital.Id);
      if (SignoVitalEncontrado!=null)
      {
        SignoVitalEncontrado.FechaHora = SignoVital.FechaHora;
        SignoVitalEncontrado.TipoSigno = SignoVital.TipoSigno;
        _appContext.SaveChanges();
      }
      return SignoVitalEncontrado;
    }
  }
}