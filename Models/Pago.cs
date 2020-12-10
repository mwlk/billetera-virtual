using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int? IdCuenta { get; set; }
        public int? IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }
        public int? CantCuotas { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; }
        public virtual Factura IdFacturaNavigation { get; set; }
    }
}
