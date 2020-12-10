using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Provincium
    {
        public Provincium()
        {
            Localidads = new HashSet<Localidad>();
        }

        public int IdProvincia { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Localidad> Localidads { get; set; }
    }
}
