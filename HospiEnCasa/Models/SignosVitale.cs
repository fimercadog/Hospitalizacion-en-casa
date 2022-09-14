using System;
using System.Collections.Generic;

namespace HospiEnCasa.Models
{
    public partial class SignosVitale
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int TipoSigno { get; set; }
    }
}
