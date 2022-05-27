using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface IBaseActivoService
    {
        Task<BaseActivoRequest> GetBaseActivos(string matricula, PaginadoRequest PaginadoResponse);
        Task<List<BaseActivo>> GetAllBaseActivos();
    }
}
