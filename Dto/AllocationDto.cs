using System.Collections.Generic;

namespace ProyectoBCP_API.Dto
{
    public class AllocationDto
    {
        public int idUser { get; set; }
        public string matricula { get; set; }
        public List<ApplicationDto> applications { get; set; }
    }
}
