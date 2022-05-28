using ProyectoBCP_API.Models.Request;
using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class ChapterLeader
    {
        public ChapterLeader()
        {
            TeamMembers = new HashSet<TeamMember>();
        }

        public int Id { get; set; }
        public int IdChapterAreaLeader { get; set; }
        public string CodMatricula { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string? NombreChapter { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public DateTime? FecActualiza { get; set; }
        public string? UsuarioActualiza { get; set; }
        public int FlgActivo { get; set; }

        public virtual ChapterAreaLeader IdChapterAreaLeaderNavigation { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
    public partial class ChapterLeaderRequest : PaginadoTotalRequest
    {
        public List<ChapterLeader> ChapterLeaders { get; set; }
    }
}
