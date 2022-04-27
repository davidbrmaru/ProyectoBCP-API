using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using ProyectoBCP_API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProyectoBCP_API.Helpers;


namespace ProyectoBCP_API.Service.Impl
{
    public class SquadService : ISquadService
    {
        private readonly DataContext _context;
        private DbSet<Squad> _dbSet;

        public SquadService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<Squad>();
        }

        public async Task<SquadRequest> GetSquad(PaginadoRequest PaginadoResponse)
        {
            int beginRecord = (PaginadoResponse.PageNumber - 1) * PaginadoResponse.PageSize;
            SquadRequest request = new SquadRequest();
            request.TotalRows = await _dbSet.Where(x => x.FlgActivo == 1).CountAsync();
            request.Squads = await _dbSet.Where(x => x.FlgActivo == 1).Skip(beginRecord).Take(PaginadoResponse.PageSize).ToListAsync();
            return request;
        }

        public async Task<List<Squad>> GetAllSquad()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Squad> GetSquadById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }


        public async Task<Squad> InsertSquad(Squad squad)
        {
            Squad squadToValidate = await GetSquadById(squad.Id);

            if (squadToValidate == null)
            {
                Squad squadToInsert = new Squad();
                squadToInsert.IdTribe = squad.IdTribe;
                squadToInsert.Nombre = squad.Nombre;
                squadToInsert.UsuarioActualiza = squad.UsuarioActualiza;
                squadToInsert.FecIngreso = System.DateTime.Now;
                squadToInsert.FecActualiza = System.DateTime.Now;
                squadToInsert.UsuarioIngresa = squad.UsuarioIngresa;
                squadToInsert.FlgActivo = Constants.FlgActivo;

                _dbSet.Add(squadToInsert);
                await _context.SaveChangesAsync();
                return squadToInsert;
            }
            else
            {
                return squadToValidate;
            }
        }

        public async Task<Squad> UpdateSquad(int id, Squad squad)
        {
            Squad squadToUpd = await GetSquadById(id);
            squadToUpd.IdTribe= squad.IdTribe;
            squadToUpd.Nombre = squad.Nombre;
            squadToUpd.FecActualiza = System.DateTime.Now;
            squadToUpd.UsuarioActualiza = squad.UsuarioActualiza;
            squadToUpd.FlgActivo = Constants.FlgActivo;

            _dbSet.Update(squadToUpd);
            await _context.SaveChangesAsync();
            return squadToUpd;
        }

        public async Task<Squad> DeleteAsync(int id)
        {
            Squad squadToDelete = await GetSquadById(id);
            _dbSet.Remove(squadToDelete);
            await _context.SaveChangesAsync();
            return squadToDelete;
        }


        public async Task<Squad> DeleteAsyncByid(int id, Squad squad)
        {
            Squad squadToDelete = await GetSquadById(id);
            squadToDelete.FecActualiza = System.DateTime.Now;
            squadToDelete.UsuarioActualiza = squad.UsuarioActualiza;
            squadToDelete.FlgActivo = Constants.FlgDesactivo;
            _dbSet.Update(squadToDelete);
            await _context.SaveChangesAsync();
            return squadToDelete;
        }
    }

}