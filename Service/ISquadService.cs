using System.Linq;
using trabajo_final_API.Models;

namespace trabajo_final_API.Service
{
    public interface ISquadService
    {
        public IQueryable<TbSquad> GetAll();        
    }
}