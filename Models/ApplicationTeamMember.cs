using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class ApplicationTeamMember
    {
        public int IdApplication { get; set; }
        public int IdTeamMember { get; set; }
        public decimal PorAsignado { get; set; }
        public string Comentario { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }

        public virtual Application IdApplicationNavigation { get; set; }
        public virtual TeamMember IdTeamMemberNavigation { get; set; }
    }
}
