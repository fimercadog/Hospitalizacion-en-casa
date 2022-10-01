using System;
using System.Collections.Generic;

namespace HospiEnCasa.Models
{
    public partial class FamiliaresDesignado
    {
        public int Id { get; set; }
        public string Parentesco { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public int Genero { get; set; }
    }
}
