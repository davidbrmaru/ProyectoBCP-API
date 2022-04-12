using ProyectoBCP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface ISubMenuService
    {

        Task<List<SubMenu>> GetSubMenu();
        Task<SubMenu> GetSubMenuById(int id);
        Task<SubMenu> InsertSubMenu(SubMenu subMenu);
        Task<SubMenu> UpdateSubMenu(int id, SubMenu subMenu);
        Task<SubMenu> DeleteAsyncByid(int id, SubMenu subMenu);
        Task<SubMenu> DeleteAsync(int id);
    }
}
