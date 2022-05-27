﻿using Microsoft.EntityFrameworkCore;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoBCP_API.Helpers;

namespace ProyectoBCP_API.Service.Impl
{
    public class TeamMemberService : ITeamMemberService
    {
        private DataContext _context;
        private DbSet<TeamMember> _dbSet;
        
        public TeamMemberService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<TeamMember>();
        }


        public async Task<TeamMember> DeleteAsync(int id)
        {
            TeamMember teamMemberToDelete = await GetTeamMemberById(id);
            _dbSet.Remove(teamMemberToDelete);
            await _context.SaveChangesAsync();
            return teamMemberToDelete;
        }

        public async Task<TeamMember> DeleteAsyncByid(int id, TeamMember teamMember)
        {
            TeamMember teamMemberToDelete = await GetTeamMemberById(id);
            teamMemberToDelete.FecActualiza = System.DateTime.Now;
            teamMemberToDelete.UsuarioActualiza = teamMember.UsuarioActualiza;
            teamMemberToDelete.FlgActivo = Constants.FlgDesactivo;
            _dbSet.Update(teamMemberToDelete);
            await _context.SaveChangesAsync();
            return teamMemberToDelete;
        }

        public async Task<TeamMemberRequest> GetTeamMember(PaginadoRequest PaginadoResponse)
        {
            int beginRecord = (PaginadoResponse.PageNumber - 1) * PaginadoResponse.PageSize;
            TeamMemberRequest response = new TeamMemberRequest();
            response.TotalRows= await _dbSet.Where(x => x.FlgActivo == 1).CountAsync();
            response.TeamMembers= await _dbSet.Where(x => x.FlgActivo == 1).OrderByDescending(x => x.Id).Skip(beginRecord).Take(PaginadoResponse.PageSize).ToListAsync();
            return response;
        }
        public async Task<List<TeamMember>> GetAllTeamMember()
        {
            return await _dbSet.Where(x => x.FlgActivo == 1).ToListAsync();
        }
        public async Task<TeamMember> GetTeamMemberById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TeamMember> InsertTeamMember(TeamMember teamMember)
        {
            TeamMember teamMemberValidate = await GetTeamMemberByMatricula(teamMember.CodMatricula);

            if (teamMemberValidate == null)
            {
                TeamMember teamMemberAdd = new TeamMember();
                teamMemberAdd.CodMatricula = teamMember.CodMatricula;
                teamMemberAdd.Nombre = teamMember.Nombre;
                teamMemberAdd.ApellidoPaterno = teamMember.ApellidoPaterno;
                teamMemberAdd.ApellidoMaterno = teamMember.ApellidoMaterno;
                teamMemberAdd.IdChapterLeader = teamMember.IdChapterLeader;
                teamMemberAdd.TipoProveedor = teamMember.TipoProveedor;
                teamMemberAdd.Empresa = teamMember.Empresa;
                teamMemberAdd.Rol = teamMember.Rol;
                teamMemberAdd.RolInsourcing = teamMember.RolInsourcing;
                teamMemberAdd.Especialidad = teamMember.Especialidad;
                teamMemberAdd.FecIngreso = System.DateTime.Now;
                teamMemberAdd.UsuarioIngresa = teamMember.UsuarioIngresa;
                teamMemberAdd.FlgActivo = Constants.FlgActivo;

                _dbSet.Add(teamMemberAdd);
                await _context.SaveChangesAsync();
                return teamMemberAdd;
            }
            else
            {
                return teamMemberValidate;
            }
        }
        public async Task<TeamMember> UpdateTeamMember(int id, TeamMember teamMember)
        {
            var teamMemberUpdate = await GetTeamMemberById(id);
            teamMemberUpdate.CodMatricula = teamMember.CodMatricula;
            teamMemberUpdate.Nombre = teamMember.Nombre;
            teamMemberUpdate.ApellidoPaterno = teamMember.ApellidoPaterno;
            teamMemberUpdate.ApellidoMaterno = teamMember.ApellidoMaterno;
            teamMemberUpdate.IdChapterLeader = teamMember.IdChapterLeader;
            teamMemberUpdate.TipoProveedor = teamMember.TipoProveedor;
            teamMemberUpdate.Empresa = teamMember.Empresa;
            teamMemberUpdate.Rol = teamMember.Rol;
            teamMemberUpdate.RolInsourcing = teamMember.RolInsourcing;
            teamMemberUpdate.Especialidad = teamMember.Especialidad;            
            teamMemberUpdate.FecActualiza = System.DateTime.Now;
            teamMemberUpdate.UsuarioActualiza = teamMember.UsuarioActualiza;
            teamMemberUpdate.FlgActivo = Constants.FlgActivo;
            _context.Update(teamMemberUpdate);
            _context.SaveChanges();
            return teamMemberUpdate;
        }

        public async Task<TeamMember> GetTeamMemberByMatricula(string matricula)
        {
            return await _dbSet.Where(p => p.CodMatricula == matricula).FirstOrDefaultAsync();
        }
    }
}
