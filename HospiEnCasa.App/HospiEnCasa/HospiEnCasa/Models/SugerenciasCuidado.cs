using System;
using System.Collections.Generic;

namespace HospiEnCasa.Models
{
    public partial class SugerenciasCuidado
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
