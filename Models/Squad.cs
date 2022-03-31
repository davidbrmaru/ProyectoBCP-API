using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class Squad
    {
        public Squad()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public int IdTribe { get; set; }
        public string Nombre { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public DateTime? FecActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public int FlgActivo { get; set; }

        public virtual Tribe IdTribeNavigation { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
