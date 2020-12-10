using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class EntidadBancarium
    {
        public EntidadBancarium()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdEntidadBancaria { get; set; }
        public string Nombre { get; set; }
        public int? IdDireccion { get; set; }
        public string RazonSocial { get; set; }

        public virtual Direccion IdEntidadBancariaNavigation { get; set; }
        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
