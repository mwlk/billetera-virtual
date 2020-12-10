using System.Collections.Generic;


#nullable disable

namespace WepAppClip.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Estado { get; set; }
        public int? IdDireccion { get; set; }
        public string NroTelefono { get; set; }
        public string NroDni { get; set; }
        public byte[] FrontalDni { get; set; }
        public byte[] TraseraDni { get; set; }
        public string Email { get; set; }
        public int IdUsuario { get; set; }

        public virtual Direccion IdDireccionNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
