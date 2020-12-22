using System;
using System.Collections.Generic;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? Estado { get; set; }
        public string Email { get; set; }
    }
}
