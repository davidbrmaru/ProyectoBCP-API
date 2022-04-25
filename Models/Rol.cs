using System;
using System.Collections.Generic;
using System.Linq;
#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string CodRol { get; set; }
        public string Nombre { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public DateTime? FecActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public int FlgActivo { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
