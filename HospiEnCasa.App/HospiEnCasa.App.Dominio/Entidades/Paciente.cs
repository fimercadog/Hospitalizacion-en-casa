using System;

namespace HospiEnCasa.App.Dominio
{
  public class Paciente : Persona
  {
    public string Direccion { get; set; }
    public string Nombre { get; set; }
    public float latitud { get; set; }
    public float longitud { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }


  }

}