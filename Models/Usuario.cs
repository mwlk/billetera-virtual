using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre de usuario")]
        [MinLength(4,ErrorMessage = "Nombre de Usuario debe ser al menos 5 caracteres")]
        public string NombreUsuario { get; set; }
        [Required]
        [MinLength(8,ErrorMessage = "Password mayor a 8 digitos please")]
        public string Password { get; set; }
        public DateTime? FechaAlta { get; set; }
        [Required(ErrorMessage ="Asignar un Estado al Usuario")]
        public int? Estado { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
