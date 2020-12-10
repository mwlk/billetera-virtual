using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Inversions = new HashSet<Inversion>();
            Operacions = new HashSet<Operacion>();
            Pagos = new HashSet<Pago>();
            TransferenciumIdCuentaDestinoNavigations = new HashSet<Transferencium>();
            TransferenciumIdCuentaOrigenNavigations = new HashSet<Transferencium>();
        }

        public int IdCuenta { get; set; }
        public int? IdEntidadBancaria { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTipoMoneda { get; set; }
        public string Cvu { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? Estado { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? TopeDescubierto { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual EntidadBancarium IdEntidadBancariaNavigation { get; set; }
        public virtual TipoMonedum IdTipoMonedaNavigation { get; set; }
        public virtual ICollection<Inversion> Inversions { get; set; }
        public virtual ICollection<Operacion> Operacions { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Transferencium> TransferenciumIdCuentaDestinoNavigations { get; set; }
        public virtual ICollection<Transferencium> TransferenciumIdCuentaOrigenNavigations { get; set; }
    }
}
