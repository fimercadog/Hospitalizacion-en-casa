using System;
using System.Collections.Generic;

namespace HospiEnCasa.Models
{
    public partial class Medico
    {
        public int Id { get; set; }
        public string Especialidad { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string RegistroRethus { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public int Genero { get; set; }
    }
}
