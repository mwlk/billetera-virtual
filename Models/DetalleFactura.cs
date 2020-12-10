using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int? IdFactura { get; set; }
        public int? IdServicio { get; set; }
        public string SubTotal { get; set; }

        public virtual Factura IdDetalleFacturaNavigation { get; set; }
        public virtual Servicio IdServicioNavigation { get; set; }
    }
}
