using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoBCP_API.Service
{
    public interface IUserService
    {

        Task<UserRequest> GetUser(PaginadoRequest PaginadoResponse);
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> InsertUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<User> DeleteAsyncByid(int id, User user);
        Task<User> DeleteAsync(int id);


    }
}
