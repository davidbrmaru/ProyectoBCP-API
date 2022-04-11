using ProyectoBCP_API.Models;
using ProyectoBCP_API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProyectoBCP_API.Helpers;

namespace ProyectoBCP_API.Service.Impl
{
    public class ApplicationService : IApplicationService
    {
        private readonly DataContext _context;
        private DbSet<Application> _dbSet;

        public ApplicationService(DataContext context)
            {
            _context = context;
            _dbSet = context.Set<Application>();
        }

        public async Task<Application> DeleteAsync(int id)
        {
            Application applicationToDelete = await GetApplicationById(id);
            _dbSet.Remove(applicationToDelete);
            await _context.SaveChangesAsync();
            return applicationToDelete;
        }

        public async Task<Application> DeleteAsyncByid(int id, Application application)
        {
            Application applicationToDelete = await GetApplicationById(id);
            applicationToDelete.FecActualiza = System.DateTime.Now;
            applicationToDelete.UsuarioActualiza = application.UsuarioActualiza;
            applicationToDelete.FlgActivo = Constants.FlgDesactivo;
            _dbSet.Update(applicationToDelete);
            await _context.SaveChangesAsync();
            return applicationToDelete;
        }

       

        public async Task<List<Application>> GetApplication()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Application> GetApplicationById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Application> GetApplicationByCode(string codigoApp)
        {
            return await _dbSet.Where(p => p.CodApplication == codigoApp).FirstOrDefaultAsync();
        }

        public async Task<Application> InsertApplication(Application application)
        {
            Application applicationToValidate = await GetApplicationByCode(application.CodApplication);

            if (applicationToValidate == null)
            {
                Application applicationToInsert = new Application();
                applicationToInsert.CodApplication = application.CodApplication;
                applicationToInsert.IdSquad = application.IdSquad;
                applicationToInsert.Name = application.Name;
                applicationToInsert.CodOwner = application.CodOwner;
                applicationToInsert.BindingBlock = application.BindingBlock;
                applicationToInsert.UsuarioActualiza = application.UsuarioActualiza;
                applicationToInsert.FecIngreso = System.DateTime.Now;
                applicationToInsert.FecActualiza = System.DateTime.Now;
                applicationToInsert.UsuarioIngresa = application.UsuarioIngresa;
                applicationToInsert.FlgActivo = Constants.FlgActivo;

                _dbSet.Add(applicationToInsert);
                await _context.SaveChangesAsync();
                return applicationToInsert;
            }
            else
            {
                return applicationToValidate;
            }
        }

        public async Task<Application> UpdateApplication(int id, Application application)
        {
            Application applicationToUpd = await GetApplicationById(id);
            applicationToUpd.CodApplication = application.CodApplication;
            applicationToUpd.IdSquad = application.IdSquad;
            applicationToUpd.Name = application.Name;
            applicationToUpd.CodOwner = application.CodOwner;
            applicationToUpd.BindingBlock = application.BindingBlock;
            applicationToUpd.FecActualiza = System.DateTime.Now;
            applicationToUpd.UsuarioActualiza = application.UsuarioActualiza;
            
            _dbSet.Update(applicationToUpd);
            await _context.SaveChangesAsync();
            return applicationToUpd;
        }
    }



  }

