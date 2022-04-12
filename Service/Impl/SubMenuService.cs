using ProyectoBCP_API.Models;
using ProyectoBCP_API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProyectoBCP_API.Helpers;

namespace ProyectoBCP_API.Service.Impl
{
    public class SubMenuService :ISubMenuService
    {
        private readonly DataContext _context;
        private DbSet<SubMenu> _dbSet;

        public SubMenuService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<SubMenu>();
        }
        public async Task<List<SubMenu>> GetSubMenu()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<SubMenu> GetSubMenuById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<SubMenu> InsertSubMenu(SubMenu subMenu)
        {
            SubMenu subMenuToValidate = await GetSubMenuById(subMenu.Id);

            if (subMenuToValidate == null)
            {
                SubMenu subMenuToInsert = new SubMenu();
                subMenuToInsert.IdMenu = subMenu.IdMenu;
                subMenuToInsert.Name = subMenu.Name;
                subMenuToInsert.Url = subMenu.Url;
                subMenuToInsert.Icon = subMenu.Icon;
                subMenuToInsert.UsuarioActualiza = subMenu.UsuarioActualiza;
                subMenuToInsert.FecIngreso = System.DateTime.Now;
                subMenuToInsert.FecActualiza = System.DateTime.Now;
                subMenuToInsert.UsuarioIngresa = subMenu.UsuarioIngresa;
                subMenuToInsert.FlgActivo = Constants.FlgActivo;

                _dbSet.Add(subMenuToInsert);
                await _context.SaveChangesAsync();
                return subMenuToInsert;
            }
            else
            {
                return subMenuToValidate;
            }
        }

        public async Task<SubMenu> UpdateSubMenu(int id, SubMenu subMenu)
        {
            SubMenu SubMenuToUpd = await GetSubMenuById(id);
            SubMenuToUpd.IdMenu = subMenu.IdMenu;
            SubMenuToUpd.Name = subMenu.Name;
            SubMenuToUpd.Url = subMenu.Url;
            SubMenuToUpd.Icon = subMenu.Icon;
            SubMenuToUpd.FecActualiza = System.DateTime.Now;
            SubMenuToUpd.UsuarioActualiza = subMenu.UsuarioActualiza;
            SubMenuToUpd.FlgActivo = Constants.FlgActivo;

            _dbSet.Update(SubMenuToUpd);
            await _context.SaveChangesAsync();
            return SubMenuToUpd;
        }




        public async Task<SubMenu> DeleteAsync(int id)
        {
            SubMenu subMenuToDelete = await GetSubMenuById(id);
            _dbSet.Remove(subMenuToDelete);
            await _context.SaveChangesAsync();
            return subMenuToDelete;
        }


        public async Task<SubMenu> DeleteAsyncByid(int id, SubMenu subMenu)
        {
            SubMenu subMenuToDelete = await GetSubMenuById(id);
            subMenuToDelete.FecActualiza = System.DateTime.Now;
            subMenuToDelete.UsuarioActualiza = subMenu.UsuarioActualiza;
            subMenuToDelete.FlgActivo = Constants.FlgDesactivo;
            _dbSet.Update(subMenuToDelete);
            await _context.SaveChangesAsync();
            return subMenuToDelete;
        }

    }
}
