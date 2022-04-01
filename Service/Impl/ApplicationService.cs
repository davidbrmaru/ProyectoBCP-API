using Microsoft.EntityFrameworkCore;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Models;
using System.Linq;
using trabajo_final_API.Models;
using trabajo_final_API.Service;

namespace ProyectoBCP_API.Service.Impl
{
    public class ApplicationService : IApplicationService
    {
        private readonly DataContext _context;
        public ApplicationService(DataContext context)
            {
                this._context = context;
            }

           public IQueryable<Application> GetAll()
            {    
             return _context.Applications.Include(c => c.Id).OrderByDescending(a => a.Id);
            }
        }



  }

