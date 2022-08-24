using System;
namespace HospiEnCasa.App.Dominio
{
  public class Historia
  {
    public int Id { get; set; }
    public string Diagnostico { get; set; }
    public string Entorno { get; set; }

    private SugerenciaCuidado idSugerenciaCuidado;

    public SugerenciaCuidado GetIdSugerenciaCuidado()
    {
      return idSugerenciaCuidado;
    }

    public void SetIdSugerenciaCuidado(SugerenciaCuidado value)
    {
      idSugerenciaCuidado = value;
    }
  }
}