using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public interface IReposotorioEnfermera
  {
    IEnumerable<Enfermera> GetAllEnfermeras();

    Enfermera AddEnfermera(Enfermera Enfermera);
    Enfermera UpdateEnfermera(Enfermera Enfermera);

    void DeleteEnfermera(int idEnfermera);

    Enfermera GetEnfermera(int idEnfermera);

  }
}