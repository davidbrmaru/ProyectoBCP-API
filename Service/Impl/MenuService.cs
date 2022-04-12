using ProyectoBCP_API.Models;
using ProyectoBCP_API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProyectoBCP_API.Helpers;


namespace ProyectoBCP_API.Service.Impl
{
    public class MenuService: IMenuService
    {
        private readonly DataContext _context;
        private DbSet<Menu> _dbSet;

        public MenuService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<Menu>();
        }

        public async Task<List<Menu>> GetMenu()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Menu> InsertMenu(Menu menu)
        {
            Menu menuToValidate = await GetMenuById(menu.Id);

            if (menuToValidate == null)
            {
                Menu menuToInsert = new Menu();
                menuToInsert.CodMenu= menu.CodMenu;
                menuToInsert.Nombre = menu.Nombre;
                menuToInsert.UsuarioActualiza = menu.UsuarioActualiza;
                menuToInsert.FecIngreso = System.DateTime.Now;
                menuToInsert.FecActualiza = System.DateTime.Now;
                menuToInsert.UsuarioIngresa = menu.UsuarioIngresa;
                menuToInsert.Tittle = true;

                _dbSet.Add(menuToInsert);
                await _context.SaveChangesAsync();
                return menuToInsert;
            }
            else
            {
                return menuToValidate;
            }
        }

        public async Task<Menu> UpdateMenu(int id, Menu menu)
        {
            Menu menuToUpd = await GetMenuById(id);
            menuToUpd.CodMenu = menu.CodMenu;
            menuToUpd.Nombre = menu.Nombre;
            menuToUpd.FecActualiza = System.DateTime.Now;
            menuToUpd.UsuarioActualiza = menu.UsuarioActualiza;
            menuToUpd.Tittle = true;

            _dbSet.Update(menuToUpd);
            await _context.SaveChangesAsync();
            return menuToUpd;
        }


        public async Task<Menu> DeleteAsync(int id)
        {
            Menu menuToDelete = await GetMenuById(id);
            _dbSet.Remove(menuToDelete);
            await _context.SaveChangesAsync();
            return menuToDelete;
        }


        public async Task<Menu> DeleteAsyncByid(int id, Menu menu)
        {
            Menu menuToDelete = await GetMenuById(id);
            menuToDelete.FecActualiza = System.DateTime.Now;
            menuToDelete.UsuarioActualiza = menu.UsuarioActualiza;
            //en la tabla se definio como BIT
            menuToDelete.Tittle = false  ;
            _dbSet.Update(menuToDelete);
            await _context.SaveChangesAsync();
            return menuToDelete;
        }

    }
}
