using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int IdServicio { get; set; }
        public int? IdTipoServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

        public virtual TipoServicio IdServicioNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
