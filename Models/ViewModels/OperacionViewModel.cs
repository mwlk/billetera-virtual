using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppClip.Models.ViewModels
{
    public class OperacionViewModel
    {
        public int IdOperacion { get; set; }
        public int? IdTipoOperacion { get; set; }
        public int? IdCuenta { get; set; }
        public string NroOperacion { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaOperacion { get; set; }
        public string HoraOperacion { get; set; }
        public decimal? Monto { get; set; }

        public string TipoOperacion { get; set; }
    }
}
