using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Pagos = new HashSet<Pago>();
        }

        public int IdFactura { get; set; }
        public DateTime? FechaElaboracion { get; set; }
        public decimal? Total { get; set; }
        public int? Estado { get; set; }
        public string FechaVencimiento { get; set; }

        public virtual DetalleFactura DetalleFactura { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
