using ProyectoBCP_API.Models;
using ProyectoBCP_API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProyectoBCP_API.Helpers;
using ProyectoBCP_API.Dto;

namespace ProyectoBCP_API.Service.Impl
{
    public class ApplicationTeamMemberService : IApplicationTeamMemberService
    {

        private readonly DataContext _context;
        private DbSet<ApplicationTeamMember> _dbSet;

        public ApplicationTeamMemberService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<ApplicationTeamMember>();
        }

        public async Task<AllocationDto> InsertApplicationTeamMember(AllocationDto allocationDto)
        {
            List<ApplicationTeamMember> list = await GetApplicationByCode(allocationDto.idUser);
            _dbSet.RemoveRange(list);

            IList<ApplicationTeamMember> listAdd = new List<ApplicationTeamMember>();

            allocationDto.aplications.ForEach(a => {
                    listAdd.Add(new ApplicationTeamMember()
                        {
                            IdTeamMember = allocationDto.idUser,
                            IdApplication = a.idApplication,
                            PorAsignado = a.percentage,
                            Comentario = a.comment,
                            FecIngreso  = System.DateTime.Now,
                            UsuarioIngresa = allocationDto.matricula
                         }
                    ); 
                }
            );

            _context.ApplicationTeamMembers.AddRange(listAdd);
            _context.SaveChanges();
            return allocationDto;
        }



        public async Task<List<ApplicationTeamMember>> GetApplicationByCode(int idTeamMember)
        {
            return await _dbSet.Where(a => a.IdTeamMember == idTeamMember).ToListAsync();
        }
    }
}
