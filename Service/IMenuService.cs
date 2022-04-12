using ProyectoBCP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoBCP_API.Service
{
    public interface IMenuService
    {
        Task<List<Menu>> GetMenu();
        Task<Menu> GetMenuById(int id);
        Task<Menu> InsertMenu(Menu menu);
        Task<Menu> UpdateMenu(int id, Menu menu);
        Task<Menu> DeleteAsyncByid(int id, Menu menu);
        Task<Menu> DeleteAsync(int id);

    }
}
