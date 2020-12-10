using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Transferencium
    {
        public int IdTransferencia { get; set; }
        public int? IdCuentaOrigen { get; set; }
        public int? IdCuentaDestino { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? FechaOperacion { get; set; }
        public string HoraOperacion { get; set; }
        public string Motivo { get; set; }

        public virtual Cuentum IdCuentaDestinoNavigation { get; set; }
        public virtual Cuentum IdCuentaOrigenNavigation { get; set; }
    }
}
