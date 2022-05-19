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
    public class UserService : IUserService
    {

        private readonly DataContext _context;
        private DbSet<User> _dbSet;

        public UserService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }


        public async Task<UserRequest> GetUser(PaginadoRequest PaginadoResponse)
        {
            int beginRecord = (PaginadoResponse.PageNumber - 1) * PaginadoResponse.PageSize;
            UserRequest request = new UserRequest();
            request.TotalRows = await _dbSet.Where(x => x.FlgActivo == 1).CountAsync();
            request.Users = await _dbSet.Where(x => x.FlgActivo == 1).OrderByDescending(x => x.Id).Skip(beginRecord).Take(PaginadoResponse.PageSize).ToListAsync();
            return request;
        }

        public async Task<List<User>> GetAllUser(){
           return await _dbSet.ToListAsync();
                }

        public async Task<User> GetUserById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User> GetUserByCodMatriculaPassword(string codMatricula, string password)
        {
            return await _dbSet.Where(p => p.CodMatricula == codMatricula && p.Password == password).FirstOrDefaultAsync();
        }

        public async Task<User> InsertUser(User user)
        {
            User userToValidate = await GetUserById(user.Id);

            if (userToValidate == null)
            {
                User userToInsert = new User();
                userToInsert.CodMatricula = user.CodMatricula;
                userToInsert.Password = user.Password;
                userToInsert.Correo = user.Correo;
                userToInsert.IdRol = user.IdRol;
                userToInsert.UsuarioActualiza = user.UsuarioActualiza;
                userToInsert.FecIngreso = System.DateTime.Now;
                userToInsert.FecActualiza = System.DateTime.Now;
                userToInsert.UsuarioIngresa = user.UsuarioIngresa;
                userToInsert.FlgActivo = Constants.FlgActivo;

                _dbSet.Add(userToInsert);
                await _context.SaveChangesAsync();
                return userToInsert;
            }
            else
            {
                return userToValidate;
            }
         }

        public async Task<User> UpdateUser(int id, User user)
        {
            User userToUpd = await GetUserById(id);
            userToUpd.Password = user.Password;
            userToUpd.IdRol = user.IdRol;
            userToUpd.FecActualiza = System.DateTime.Now;
            userToUpd.UsuarioActualiza = user.UsuarioActualiza;
            userToUpd.FlgActivo = Constants.FlgActivo;

            _dbSet.Update(userToUpd);
            await _context.SaveChangesAsync();
            return userToUpd;
        }
        public async Task<User> DeleteAsync(int id)
         {
                User userToDelete = await GetUserById(id);
                _dbSet.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return userToDelete;
         }


        public async Task<User> DeleteAsyncByid(int id, User user)
          {
                User userToDelete = await GetUserById(id);
                userToDelete.FecActualiza = System.DateTime.Now;
                userToDelete.UsuarioActualiza = user.UsuarioActualiza;
                userToDelete.FlgActivo = Constants.FlgDesactivo;
                _dbSet.Update(userToDelete);
                await _context.SaveChangesAsync();
                return userToDelete;
          }
     }
    
}
