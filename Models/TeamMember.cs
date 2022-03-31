using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class TeamMember
    {
        public int Id { get; set; }
        public string CodMatricula { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdChapterLeader { get; set; }
        public string TipoProveedor { get; set; }
        public string Empresa { get; set; }
        public string Rol { get; set; }
        public string RolInsourcing { get; set; }
        public string Especialidad { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public DateTime? FecActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public int FlgActivo { get; set; }

        public virtual ChapterLeader IdChapterLeaderNavigation { get; set; }
    }
}
