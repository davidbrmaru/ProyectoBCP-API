using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBCP_API.Models
{
    public partial class Application
    {
        public int Id { get; set; }
        public string CodAplicacion { get; set; }
        public string Nombre { get; set; }
        public string CodOwner { get; set; }
        public int IdSquad { get; set; }
        public string BindingBlock { get; set; }
        public DateTime FecIngreso { get; set; }
        public string UsuarioIngresa { get; set; }
        public DateTime? FecActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public int FlgActivo { get; set; }

        public virtual Squad IdSquadNavigation { get; set; }
    }
}
