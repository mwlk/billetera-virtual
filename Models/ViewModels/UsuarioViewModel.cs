using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppClip.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? Estado { get; set; }
        public string Email { get; set; }
    }
}
