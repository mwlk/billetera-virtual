using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Localidad
    {
        public Localidad()
        {
            Direccions = new HashSet<Direccion>();
        }

        public int IdLocalidad { get; set; }
        public string Nombre { get; set; }
        public int? IdProvincia { get; set; }
        public string CodigoPostal { get; set; }

        public virtual Provincium IdProvinciaNavigation { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
