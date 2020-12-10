using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class TipoMonedum
    {
        public TipoMonedum()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdTipoMoneda { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Valor { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
