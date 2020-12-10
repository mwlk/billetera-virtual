using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Inversion
    {
        public int IdInversion { get; set; }
        public int? IdCuenta { get; set; }
        public int? IdTipoInversion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? CantidadDias { get; set; }
        public decimal? MontoInicial { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; }
        public virtual TipoInversion IdInversionNavigation { get; set; }
    }
}
