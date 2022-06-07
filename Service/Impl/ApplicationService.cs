using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using ProyectoBCP_API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProyectoBCP_API.Helpers;
using ProyectoBCP_API.Jwt.Session;

namespace ProyectoBCP_API.Service.Impl
{
    public class ApplicationService : IApplicationService
    {
        private readonly DataContext _context;
        private DbSet<Application> _dbSet;
        private IUserSession _iUserSession;

        public ApplicationService(DataContext context, IUserSession iUserSession)
            {
            _context = context;
            _dbSet = context.Set<Application>();
            _iUserSession = iUserSession;
        }
        public async Task<ApplicationRequest> GetApplication(PaginadoRequest PaginadoResponse)
        {
            int beginRecord = (PaginadoResponse.PageNumber - 1) * PaginadoResponse.PageSize;
            ApplicationRequest request = new ApplicationRequest();
            request.TotalRows = await _dbSet.Where(x => x.FlgActivo == 1).CountAsync();
            request.Applications = await _dbSet.Where(x => x.FlgActivo == 1).OrderByDescending(x => x.Id).Skip(beginRecord).Take(PaginadoResponse.PageSize).ToListAsync();
            return request;
        }
        public async Task<List<Application>> GetAllApplication()
        {
            return await _dbSet.Where(x => x.FlgActivo == 1).ToListAsync();
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
            applicationToDelete.UsuarioActualiza = _iUserSession.Username;
            applicationToDelete.FlgActivo = Constants.FlgDesactivo;
            _dbSet.Update(applicationToDelete);
            await _context.SaveChangesAsync();
            return applicationToDelete;
        }

       


        public async Task<Application> GetApplicationById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Application> GetApplicationByCode(string codigoApp)
        {
            return await _dbSet.Where(p => p.CodAplicacion == codigoApp).FirstOrDefaultAsync();
        }

        public async Task<Application> InsertApplication(Application application)
        {
            Application applicationToValidate = await GetApplicationByCode(application.CodAplicacion);

            if (applicationToValidate == null)
            {
                Application applicationToInsert = new Application();
                applicationToInsert.CodAplicacion = application.CodAplicacion;
                applicationToInsert.IdSquad = application.IdSquad;
                applicationToInsert.Nombre = application.Nombre;
                applicationToInsert.CodOwner = application.CodOwner;
                applicationToInsert.BindingBlock = application.BindingBlock;
                applicationToInsert.FecIngreso = System.DateTime.Now;
                applicationToInsert.UsuarioIngresa = _iUserSession.Username;
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
            applicationToUpd.CodAplicacion = application.CodAplicacion;
            applicationToUpd.IdSquad = application.IdSquad;
            applicationToUpd.Nombre = application.Nombre;
            applicationToUpd.CodOwner = application.CodOwner;
            applicationToUpd.BindingBlock = application.BindingBlock;
            applicationToUpd.FecActualiza = System.DateTime.Now;
            applicationToUpd.UsuarioActualiza = _iUserSession.Username;
            
            _dbSet.Update(applicationToUpd);
            await _context.SaveChangesAsync();
            return applicationToUpd;
        }
    }



  }

