using System.Linq;
using trabajo_final_API.Models;
using trabajo_final_API.Models.Request;

namespace trabajo_final_API.Service
{
    public interface ITribuService
    {
        public IQueryable<TbTribu> GetAll();
    }
}
