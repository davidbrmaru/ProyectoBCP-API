using System;
using System.Collections.Generic;
using System.Linq;
#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class Menu
    {
        public Menu()
        {
            SubMenus = new HashSet<SubMenu>();
        }

        public int Id { get; set; }
        public string CodMenu { get; set; }
        public string Nombre { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public DateTime? FecActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public bool Tittle { get; set; }

        public virtual ICollection<SubMenu> SubMenus { get; set; }
    }
}