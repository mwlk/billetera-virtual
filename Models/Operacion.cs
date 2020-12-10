using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Operacion
    {
        public int IdOperacion { get; set; }
        public int? IdTipoOperacion { get; set; }
        public int? IdCuenta { get; set; }
        public string NroOperacion { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaOperacion { get; set; }
        public string HoraOperacion { get; set; }
        public decimal? Monto { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; }
        public virtual TipoOperacion IdOperacionNavigation { get; set; }
    }
}
