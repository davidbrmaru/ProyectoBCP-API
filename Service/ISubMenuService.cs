using ProyectoBCP_API.Models;
using ProyectoBCP_API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface ISubMenuService
    {
        Task<SubMenuRequest> GetSubMenu(PaginadoRequest PaginadoResponse);
        Task<List<SubMenu>> GetAllSubMenu();
        Task<SubMenu> GetSubMenuById(int id);
        Task<SubMenu> InsertSubMenu(SubMenu subMenu);
        Task<SubMenu> UpdateSubMenu(int id, SubMenu subMenu);
        Task<SubMenu> DeleteAsyncByid(int id, SubMenu subMenu);
        Task<SubMenu> DeleteAsync(int id);
    }
}
