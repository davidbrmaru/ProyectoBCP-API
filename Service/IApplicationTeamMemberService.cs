using ProyectoBCP_API.Dto;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface IApplicationTeamMemberService
    {
        Task<AllocationDto> InsertApplicationTeamMember(AllocationDto allocationDto);
    }
}
