using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class TipoInversion
    {
        public int IdTipoInversion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Tasa { get; set; }

        public virtual Inversion Inversion { get; set; }
    }
}
