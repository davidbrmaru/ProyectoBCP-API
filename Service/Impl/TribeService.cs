using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProyectoBCP_API.Service.Impl
{
    public class TribeService : ITribeService
    {

        private readonly DataContext _context;
        private DbSet<Tribe> _dbSet;

        public TribeService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<Tribe>();
        }

        public async Task<TribeRequest> GetTribe(PaginadoRequest PaginadoResponse)
        {
            int beginRecord = (PaginadoResponse.PageNumber - 1) * PaginadoResponse.PageSize;
            TribeRequest request = new TribeRequest();
            request.TotalRows = await _dbSet.Where(x => x.FlgActivo == 1).CountAsync();
            request.Tribes = await _dbSet.Where(x => x.FlgActivo == 1).OrderByDescending(x => x.Id).Skip(beginRecord).Take(PaginadoResponse.PageSize).ToListAsync();
            return request;
        }

        public async Task<List<Tribe>> GetAllTribe()
        {
            return await _dbSet.Where(x => x.FlgActivo == 1).ToListAsync();
        }

        public async Task<Tribe> GetTribeById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Tribe> InsertTribe(Tribe tribe)
        {
            Tribe tribeToValidate = await GetTribeById(tribe.Id);

            if (tribeToValidate == null)
            {
                Tribe tribeToInsert = new Tribe();
                tribeToInsert.Nombre = tribe.Nombre;
                tribeToInsert.Tipo = tribe.Tipo;
                tribeToInsert.UsuarioActualiza = tribe.UsuarioActualiza;
                tribeToInsert.FecIngreso = System.DateTime.Now;
                tribeToInsert.FecActualiza = System.DateTime.Now;
                tribeToInsert.UsuarioIngresa = tribe.UsuarioIngresa;
                tribeToInsert.FlgActivo = Constants.FlgActivo;

                _dbSet.Add(tribeToInsert);
                await _context.SaveChangesAsync();
                return tribeToInsert;
            }
            else
            {
                return tribeToValidate;
            }
        }

        public async Task<Tribe> DeleteAsync(int id)
        {
            Tribe tribeToDelete = await GetTribeById(id);
            _dbSet.Remove(tribeToDelete);
            await _context.SaveChangesAsync();
            return tribeToDelete;

        }

        public async Task<Tribe> DeleteAsyncByid(int id, Tribe tribe)
        {
            Tribe tribeToDelete = await GetTribeById(id);
            tribeToDelete.FecActualiza = System.DateTime.Now;
            tribeToDelete.UsuarioActualiza = tribe.UsuarioActualiza;
            tribeToDelete.FlgActivo = Constants.FlgDesactivo;
            _dbSet.Update(tribeToDelete);
            await _context.SaveChangesAsync();
            return tribeToDelete;
        }

        

        public async Task<Tribe> UpdateTribe(int id, Tribe tribe)
        {
            Tribe tribeToUpd = await GetTribeById(id);
            tribeToUpd.Nombre = tribe.Nombre;
            tribeToUpd.Tipo = tribe.Tipo;
            tribeToUpd.FecActualiza = System.DateTime.Now;
            tribeToUpd.UsuarioActualiza = tribe.UsuarioActualiza;
            tribeToUpd.FlgActivo = tribe.FlgActivo;

            _dbSet.Update(tribeToUpd);
            await _context.SaveChangesAsync();
            return tribeToUpd;
        }
    }
}
