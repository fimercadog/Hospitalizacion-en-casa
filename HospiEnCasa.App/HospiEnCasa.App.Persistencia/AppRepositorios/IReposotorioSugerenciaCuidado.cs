using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public interface IReposotorioSugerenciaCuidado
  {
    IEnumerable<SugerenciaCuidado> GetAllSugerenciaCuidados();

    SugerenciaCuidado AddSugerenciaCuidado(SugerenciaCuidado SugerenciaCuidado);
    SugerenciaCuidado UpdateSugerenciaCuidado(SugerenciaCuidado SugerenciaCuidado);

    void DeleteSugerenciaCuidado(int idSugerenciaCuidado);

    SugerenciaCuidado GetSugerenciaCuidado(int idSugerenciaCuidado);

  }
}