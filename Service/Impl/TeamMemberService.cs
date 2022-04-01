using ProyectoBCP_API.Data;
using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System.Linq;

namespace ProyectoBCP_API.Service.Impl
{
    public class TeamMemberService : ITeamMemberService
    {

        private readonly DataContext _context;
        const int STATUS_ACTIVE= 1;
        const int STATUS_INACTIVE = 0;

        public TeamMemberService(DataContext context)
        {
            _context = context;
        }

        public void Add(TeamMemberRequest request)
        {
            var teamMember = new TeamMember();
            teamMember.CodMatricula = request.CodMatricula;
            teamMember.Nombre = request.Nombre;
            teamMember.ApellidoPaterno = request.ApellidoPaterno;
            teamMember.ApellidoMaterno = request.ApellidoMaterno;
            teamMember.IdChapterLeader = request.IdChapterLeader;
            teamMember.TipoProveedor = request.TipoProveedor;
            teamMember.Empresa = request.Empresa;
            teamMember.Rol = request.Rol;
            teamMember.RolInsourcing = request.RolInsourcing;
            teamMember.Especialidad = request.Especialidad;
            teamMember.FecIngreso = new System.DateTime();
            teamMember.UsuarioIngresa = request.Usuario;
            teamMember.FecActualiza = new System.DateTime();
            teamMember.UsuarioActualiza = "";
            teamMember.FlgActivo = STATUS_ACTIVE;          
            _context.Add(teamMember);
            _context.SaveChanges();
        }

        public void Edit(TeamMemberRequest request)
        {
            var teamMember = _context.TeamMembers.Find(request.Id);
            teamMember.CodMatricula = request.CodMatricula;
            teamMember.Nombre = request.Nombre;
            teamMember.ApellidoPaterno = request.ApellidoPaterno;
            teamMember.ApellidoMaterno = request.ApellidoMaterno;
            teamMember.IdChapterLeader = request.IdChapterLeader;
            teamMember.TipoProveedor = request.TipoProveedor;
            teamMember.Empresa = request.Empresa;
            teamMember.Rol = request.Rol;
            teamMember.RolInsourcing = request.RolInsourcing;
            teamMember.Especialidad = request.Especialidad;
            teamMember.FecIngreso = new System.DateTime();
            teamMember.UsuarioIngresa = request.Usuario;
            teamMember.FecActualiza = new System.DateTime();
            teamMember.UsuarioActualiza = "";
            teamMember.FlgActivo = STATUS_ACTIVE;
            _context.Update(teamMember);
            _context.SaveChanges();
        }

        public void Delete(TeamMemberRequest request)
        {
            var teamMember = _context.TeamMembers.Find(request.Id);
            teamMember.FlgActivo = STATUS_INACTIVE;
            _context.Update(teamMember);
            _context.SaveChanges();
        }

        public IQueryable<TeamMember> GetAll()
        {
            return _context.TeamMembers.OrderByDescending(x => x.Id);
        }
    }
}
