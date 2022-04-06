using Microsoft.EntityFrameworkCore;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trabajo_final_API.Models;

namespace ProyectoBCP_API.Service.Impl
{
    public class ApplicationService : IApplicationService
    {
        private readonly DataContext _context;
        public ApplicationService(DataContext context)
            {
                this._context = context;
            }

        public Task<Application> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Application> DeleteAsyncByid(int id, Application application)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Application> GetAll()
            {    
             return _context.Applications.Include(c => c.Id).OrderByDescending(a => a.Id);
            }

        public Task<List<Application>> GetApplication()
        {
            throw new System.NotImplementedException();
        }

        public Task<Application> GetApplicationById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Application> InsertApplication(Application application)
        {
            throw new System.NotImplementedException();
        }

        public Task<Application> UpdateApplication(int id, Application application)
        {
            throw new System.NotImplementedException();
        }
    }



  }

