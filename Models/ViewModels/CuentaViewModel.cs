using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppClip.Models.ViewModels
{
    public class CuentaViewModel
    {

        public int IdCuenta { get; set; }
        public int? IdEntidadBancaria { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTipoMoneda { get; set; }
        public string Cvu { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? Estado { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? TopeDescubierto { get; set; }

        public string NombreCliente { get; set; }
        public string NombreBanco { get; set; }
        public string TipoMoneda  { get; set; }
    }
}
