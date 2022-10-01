using System;
using System.Collections.Generic;

namespace HospiEnCasa.Models
{
    public partial class Paciente
    {
        public int Id { get; set; }
        public string Direccion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public string Ciudad { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Apellidos { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public int Genero { get; set; }
    }
}
