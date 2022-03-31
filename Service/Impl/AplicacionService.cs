using Microsoft.EntityFrameworkCore;
using System.Linq;
using trabajo_final_API.Data;
using trabajo_final_API.Models;
using trabajo_final_API.Models.Request;
using trabajo_final_API.Service;

namespace ProyectoBCP_API.Service.Impl
{
    public class AplicacionService : IAplicacionService
    {
        private readonly DataContext _context;
        public AplicacionService(DataContext context)
            {
                this._context = context;
            }

           public IQueryable<TbAplicacion> GetAll()
            {    
             return _context.TbAplicacion.Include(c => c.Id_Aplicacion).OrderByDescending(a => a.Id_Aplicacion);
            }
        }



  }

