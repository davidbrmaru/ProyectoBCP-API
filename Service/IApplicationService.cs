using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface IApplicationService
    {

        Task<ApplicationRequest> GetApplication(PaginadoRequest PaginadoResponse);
        Task<List<Application>> GetAllApplication();
        Task<Application> GetApplicationById(int id);
        Task<Application> InsertApplication(Application application);
        Task<Application> UpdateApplication(int id, Application application);
        Task<Application> DeleteAsyncByid(int id, Application application);
        Task<Application> DeleteAsync(int id);
        Task<Application> GetApplicationByCode(string codigoApp);
    }
}
