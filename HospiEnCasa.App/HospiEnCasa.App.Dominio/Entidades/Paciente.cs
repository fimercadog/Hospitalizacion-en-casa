using System;

namespace HospiEnCasa.App.Dominio
{
  public class Paciente : Persona
  {
    public int Id { get; set; }
    public string Direccion { get; set; }
    public string Nombre { get; set; }
    public float latitud { get; set; }
    public float longitud { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }

    // asociacion

    private Enfermera idEnfermera;

    public Enfermera GetIdEnfermera()
    {
      return idEnfermera;
    }

    public void SetIdEnfermera(Enfermera value)
    {
      idEnfermera = value;
    }


    private Historia idHistoria;

    public Historia GetIdHistoria()
    {
      return idHistoria;
    }

    public void SetIdHistoria(Historia value)
    {
      idHistoria = value;
    }

    private SignoVital idSignoVital;

    public SignoVital GetIdSignoVital()
    {
      return idSignoVital;
    }

    public void SetIdSignoVital(SignoVital value)
    {
      idSignoVital = value;
    }


    private FamiliarDesignado idFamiliarDesignado;

    public FamiliarDesignado GetIdFamiliarDesignado()
    {
      return idFamiliarDesignado;
    }

    public void SetIdFamiliarDesignado(FamiliarDesignado value)
    {
      idFamiliarDesignado = value;
    }
  }

}