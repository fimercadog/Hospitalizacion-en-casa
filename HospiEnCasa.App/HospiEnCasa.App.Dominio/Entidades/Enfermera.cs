using System;

namespace HospiEnCasa.App.Dominio
{
  public class Enfermera:Persona
  {
    public int Id { get; set; }
    public string TarjetaProfesional  { get; set; }
    public int horas_laboradas { get; set; }
  }
}