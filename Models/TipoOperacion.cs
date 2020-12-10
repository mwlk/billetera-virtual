using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class TipoOperacion
    {
        public int IdTipoOperacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Tasa { get; set; }

        public virtual Operacion Operacion { get; set; }
    }
}
