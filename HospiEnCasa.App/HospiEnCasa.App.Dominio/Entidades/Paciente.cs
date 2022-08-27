using System;

namespace HospiEnCasa.App.Dominio
{
  public class Paciente : Persona
  {
    public int Id { get; set; }
    public string Direccion { get; set; }
    public string Nombre { get; set; }
    public float Latitud { get; set; }
    public float Longitud { get; set; }
    public string Ciudad { get; set; }
    public DateTime FechaNacimiento { get; set; }

    // asociacion

    public Enfermera Enfermera;

    public Enfermera GetEnfermera()
    {
      return Enfermera;
    }

    public void SetEnfermera(Enfermera value)
    {
      Enfermera = value;
    }

    public Medico Medico;

    public Medico GetMedico()
    {
      return Medico;
    }

    public void SetMedico(Medico value)
    {
      Medico = value;
    }


    public Historia Historia;

    public Historia GetHistoria()
    {
      return Historia;
    }

    public void SetHistoria(Historia value)
    {
      Historia = value;
    }

    public SignoVital idSignoVital;

    public SignoVital GetIdSignoVital()
    {
      return idSignoVital;
    }

    public void SetIdSignoVital(SignoVital value)
    {
      idSignoVital = value;
    }


    public FamiliarDesignado Familiar;

    public FamiliarDesignado GetFamiliar()
    {
      return Familiar;
    }

    public void SetFamiliar(FamiliarDesignado value)
    {
      Familiar = value;
    }
  }

}