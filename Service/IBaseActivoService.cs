using ProyectoBCP_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface IBaseActivoService
    {
        Task<List<BaseActivo>> GetBaseActivos(string matricula);
        Task<List<BaseActivo>> GetAllBaseActivos();
    }
}
