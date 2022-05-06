using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoBCP_API.Service
{
    public interface IMenuService
    {

        Task<MenuRequest> GetMenu(PaginadoRequest PaginadoResponse);
        Task<List<Menu>> GetAllMenu();
        Task<Menu> GetMenuById(int id);
        Task<Menu> InsertMenu(Menu menu);
        Task<Menu> UpdateMenu(int id, Menu menu);
        Task<Menu> DeleteAsyncByid(int id, Menu menu);
        Task<Menu> DeleteAsync(int id);

    }
}
