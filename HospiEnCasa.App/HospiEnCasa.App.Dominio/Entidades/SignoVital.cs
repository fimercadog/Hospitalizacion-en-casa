using System;

namespace HospiEnCasa.App.Dominio
{
  class SignoVital
  {
    public int Id { get; set; }
    public DateTime Fecha_Hora { get; set; }
    public string Direccion { get; set; }
    public TipoSigno Signo { get; set; }
    public float Valor { get; set; }


  }
}