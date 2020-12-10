using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class TipoServicio
    {
        public int IdTipoServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual Servicio Servicio { get; set; }
    }
}
