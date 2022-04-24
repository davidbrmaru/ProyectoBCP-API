using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class RolSubMenu
    {
        public int IdRol { get; set; }
        public int IdSubMenu { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public int FlgActivo { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual SubMenu IdSubMenuNavigation { get; set; }
    }
}
