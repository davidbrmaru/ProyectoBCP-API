using System;
using System.Collections.Generic;

namespace ProyectoBCP_API.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string CodMatricula { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public int IdRol { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public DateTime? FecActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public int FlgActivo { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
    }
}
