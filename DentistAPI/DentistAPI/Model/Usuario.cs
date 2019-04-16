using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            Procedimiento = new HashSet<Procedimiento>();
        }

        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public byte[] Huella { get; set; }

        public ICollection<Procedimiento> Procedimiento { get; set; }
    }
}
