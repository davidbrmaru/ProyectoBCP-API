using ProyectoBCP_API.Models.Request;
using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class ChapterAreaLeader
    {
        public ChapterAreaLeader()
        {
            ChapterLeaders = new HashSet<ChapterLeader>();
        }

        public int Id { get; set; }
        public string CodMatricula { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public DateTime? FecActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public int FlgActivo { get; set; }

        public virtual ICollection<ChapterLeader> ChapterLeaders { get; set; }
    }
    public partial class ChapterAreaLeaderRequest : PaginadoTotalRequest
    {
        public List<ChapterAreaLeader> ChapterAreaLeaders { get; set; }

    }
}
