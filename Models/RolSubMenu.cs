using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Models
{
    public partial class RolSubMenu
    {
        public int Id_Rol { get; set; }
        public int IdSubMenu { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public int FlgActivo { get; set; }


        public virtual Rol IdRolNavigation { get; set; }
    }
}
