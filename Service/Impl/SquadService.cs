using Microsoft.EntityFrameworkCore;
using System.Linq;
using trabajo_final_API.Data;
using trabajo_final_API.Models;
using trabajo_final_API.Models.Request;

namespace trabajo_final_API.Service.Impl
{
    public class SquadService : ISquadService
    {

        private readonly DataContext _context;
        public SquadService(DataContext context)
        {
            this._context = context;
        }

        public IQueryable<TbSquad> GetAll()
        {
            return _context.TbSquads.Include(c => c.IdTribuNavigation).OrderByDescending(a => a.Id);
        }
    }
}
