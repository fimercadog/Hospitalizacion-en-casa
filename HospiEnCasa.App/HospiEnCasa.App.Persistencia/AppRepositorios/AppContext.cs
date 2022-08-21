using Microsoft.EntityFrameworkCore;
using System;

namespace HospiEnCasa.App.Persistencia
{
  public class AppContext : DbContext
  {

    public DbSet<Persona> Personas { get; set; }
  }
}