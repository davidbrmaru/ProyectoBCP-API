using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System.Linq;

namespace ProyectoBCP_API.Service
{
    public interface ITeamMemberService
    {
        public IQueryable<TeamMember> GetAll();
        public void Add(TeamMemberRequest request);
        public void Edit(TeamMemberRequest request);
        public void Delete(TeamMemberRequest request);
    }
}