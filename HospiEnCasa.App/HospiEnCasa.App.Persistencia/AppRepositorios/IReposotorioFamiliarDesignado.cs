using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public interface IReposotorioFamiliarDesignado
  {
    IEnumerable<FamiliarDesignado> GetAllFamiliaresDesignados();

    FamiliarDesignado AddFamiliarDesignado(FamiliarDesignado FamiliarDesignado);
    FamiliarDesignado UpdateFamiliarDesignado(FamiliarDesignado FamiliarDesignado);

    void DeleteFamiliarDesignado(int idFamiliarDesignado);

    FamiliarDesignado GetFamiliarDesignado(int idFamiliarDesignado);

  }
}