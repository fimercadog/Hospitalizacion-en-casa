using System;
using System.Collections.Generic;

namespace HospiEnCasa.Models
{
    public partial class Enfermera
    {
        public int Id { get; set; }
        public string TarjetaProfesional { get; set; } = null!;
        public int HorasLaboradas { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public int Genero { get; set; }
    }
}
