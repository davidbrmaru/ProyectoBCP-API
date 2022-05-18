using ProyectoBCP_API.Models.Request;
using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class Tribe
    {
        public Tribe()
        {
            Squads = new HashSet<Squad>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public DateTime? FecActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public int FlgActivo { get; set; }

        public virtual ICollection<Squad> Squads { get; set; }

        
    }
    public partial class TribeRequest : PaginadoTotalRequest
    {
        public List<Tribe> Tribes { get; set; }

    }
}
