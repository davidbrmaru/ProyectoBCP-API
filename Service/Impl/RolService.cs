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
    public class RolService : IRolService
    {
        private readonly DataContext _context;
        private DbSet<Rol> _dbSet;

        public RolService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<Rol>();
        }


        public async Task<RolRequest> GetRol(PaginadoRequest PaginadoResponse)
        {
            int beginRecord = (PaginadoResponse.PageNumber - 1) * PaginadoResponse.PageSize;
            RolRequest request = new RolRequest();
            request.TotalRows = await _dbSet.Where(x => x.FlgActivo == 1).CountAsync();
            request.Rols = await _dbSet.Where(x => x.FlgActivo == 1).OrderByDescending(x => x.Id).Skip(beginRecord).Take(PaginadoResponse.PageSize).ToListAsync();
            return request;
        }

        public async Task<List<Rol>> GetAllRol()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Rol> GetRolById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Rol> InsertRol(Rol rol)
        {
            Rol rolToValidate = await GetRolById(rol.Id);

            if (rolToValidate == null)
            {
                Rol rolToInsert = new Rol();
                rolToInsert.CodRol = rol.CodRol;
                rolToInsert.Nombre = rol.Nombre;
                rolToInsert.UsuarioActualiza = rol.UsuarioActualiza;
                rolToInsert.FecIngreso = System.DateTime.Now;
                rolToInsert.FecActualiza = System.DateTime.Now;
                rolToInsert.UsuarioIngresa = rol.UsuarioIngresa;
                rolToInsert.FlgActivo = Constants.FlgActivo;

                _dbSet.Add(rolToInsert);
                await _context.SaveChangesAsync();
                return rolToInsert;
            }
            else
            {
                return rolToValidate;
            }
        }


        public async Task<Rol> UpdateRol(int id, Rol rol)
        {
            Rol rolToUpd = await GetRolById(id);
            rolToUpd.CodRol = rol.CodRol;
            rolToUpd.Nombre = rol.Nombre;
            rolToUpd.FecActualiza = System.DateTime.Now;
            rolToUpd.UsuarioActualiza = rol.UsuarioActualiza;
            rolToUpd.FlgActivo = Constants.FlgActivo;

            _dbSet.Update(rolToUpd);
            await _context.SaveChangesAsync();
            return rolToUpd;
        }


        public async Task<Rol> DeleteAsync(int id)
        {
            Rol rolToDelete = await GetRolById(id);
            _dbSet.Remove(rolToDelete);
            await _context.SaveChangesAsync();
            return rolToDelete;
        }


        public async Task<Rol> DeleteAsyncByid(int id, Rol rol)
        {
            Rol rolToDelete = await GetRolById(id);
            rolToDelete.FecActualiza = System.DateTime.Now;
            rolToDelete.UsuarioActualiza = rol.UsuarioActualiza;
            rolToDelete.FlgActivo = Constants.FlgDesactivo;
            _dbSet.Update(rolToDelete);
            await _context.SaveChangesAsync();
            return rolToDelete;
        }
    }
}
