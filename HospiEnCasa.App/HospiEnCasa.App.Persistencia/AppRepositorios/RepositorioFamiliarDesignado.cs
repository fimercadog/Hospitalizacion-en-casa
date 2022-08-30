using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioFamiliarDesignado : IReposotorioFamiliarDesignado
  {

    private readonly AppContext _appContext;

    public RepositorioFamiliarDesignado(AppContext appContext)
    {
      _appContext = appContext;
    }

    FamiliarDesignado IReposotorioFamiliarDesignado.AddFamiliarDesignado(FamiliarDesignado FamiliarDesignado)
    {
      var FamiliarDesignadoAdiocnado = _appContext.FamiliaresDesignados.Add(FamiliarDesignado);
      _appContext.SaveChanges();
      return FamiliarDesignadoAdiocnado.Entity;
    }

    void IReposotorioFamiliarDesignado.DeleteFamiliarDesignado(int idFamiliarDesignado)
    {
      var FamiliarDesignadoEncontrado = _appContext.FamiliaresDesignados.FirstOrDefault(p => p.Id == idFamiliarDesignado);
      if (FamiliarDesignadoEncontrado ==null)
      {
        return;
      }
      _appContext.FamiliaresDesignados.Remove(FamiliarDesignadoEncontrado);
      _appContext.SaveChanges();
    }

    IEnumerable<FamiliarDesignado> IReposotorioFamiliarDesignado.GetAllFamiliaresDesignados()
    {
      return _appContext.FamiliaresDesignados;
    }

    FamiliarDesignado IReposotorioFamiliarDesignado.GetFamiliarDesignado(int idFamiliarDesignado)
    {
      return _appContext.FamiliaresDesignados.FirstOrDefault(p => p.Id == idFamiliarDesignado);

    }

    FamiliarDesignado IReposotorioFamiliarDesignado.UpdateFamiliarDesignado(FamiliarDesignado FamiliarDesignado)
    {
      var FamiliarDesignadoEncontrado = _appContext.FamiliaresDesignados.FirstOrDefault(p => p.Id == FamiliarDesignado.Id);
      if (FamiliarDesignadoEncontrado!=null)
      {
        FamiliarDesignadoEncontrado.Nombre = FamiliarDesignado.Nombre;
        FamiliarDesignadoEncontrado.Apellidos = FamiliarDesignado.Apellidos;
        FamiliarDesignadoEncontrado.NumeroTelefono = FamiliarDesignado.NumeroTelefono;
        FamiliarDesignadoEncontrado.Genero = FamiliarDesignado.Genero;

        FamiliarDesignadoEncontrado.Parentesco = FamiliarDesignado.Parentesco;
        FamiliarDesignadoEncontrado.Correo = FamiliarDesignado.Correo;

        _appContext.SaveChanges();
      }
      return FamiliarDesignadoEncontrado;
    }
  }
}