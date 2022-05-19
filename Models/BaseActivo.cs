using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBCP_API.Models
{
    [NotMapped]
    public class BaseActivo
    {
        public string nombre_cal { get; set; }
        public string bb { get; set; }
        public string chapter { get; set; }
        public string comentario { get; set; }
        public string mat_chapter { get; set; }
        public string chapter_leader { get; set; }
        public string tipo_preper { get; set; }
        public string empresa { get; set; }
        public string matricula { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string nombre { get; set; }
        public string sq_rol { get; set; }
        public string rol_insourcing { get; set; }
        public string especialidad { get; set; }
        public string tribu { get; set; }
        public string squad { get; set; }
        public string codigo_app_asignado { get; set; }
        public decimal porcentaje_asignado { get; set; }
        
    }
}
