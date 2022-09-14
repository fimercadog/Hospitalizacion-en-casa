using System;
using System.Collections.Generic;

namespace HospiEnCasa.Models
{
    public partial class Historia
    {
        public int Id { get; set; }
        public string Diagnostico { get; set; } = null!;
        public string Entorno { get; set; } = null!;
    }
}
