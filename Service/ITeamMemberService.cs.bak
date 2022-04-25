using ProyectoBCP_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface ITeamMemberService
    {
        Task<List<TeamMember>> GetTeamMember();
        Task<TeamMember> GetTeamMemberById(int id);
        Task<TeamMember> GetTeamMemberByMatricula(string matricula);
        Task<TeamMember> InsertTeamMember(TeamMember teamMember);
        Task<TeamMember> UpdateTeamMember(int id, TeamMember teamMember);
        Task<TeamMember> DeleteAsyncByid(int id, TeamMember teamMember);
        Task<TeamMember> DeleteAsync(int id);

    }
}