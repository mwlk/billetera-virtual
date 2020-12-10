using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Direccion
    {
        public Direccion()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public int? IdLocalidad { get; set; }

        public virtual Localidad IdLocalidadNavigation { get; set; }
        public virtual EntidadBancarium EntidadBancarium { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
