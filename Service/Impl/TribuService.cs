using Microsoft.EntityFrameworkCore;
using System.Linq;
using trabajo_final_API.Data;
using trabajo_final_API.Models;
using trabajo_final_API.Models.Request;

namespace trabajo_final_API.Service.Impl
{
    public class TribuService : ITribuService
    {

        private readonly DataContext _context;
        public TribuService(DataContext context)
        {
            this._context = context;
        }

        public IQueryable<TbTribu> GetAll()
        {
            return _context.TbTribus.Include(c => c.TbSquads).OrderByDescending(a => a.Id);
        }
    }
}
