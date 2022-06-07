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
    public class MenuService: IMenuService
    {
        private readonly DataContext _context;
        private DbSet<Menu> _dbSet;
        private IUserSession _iUserSession;

        public MenuService(DataContext context, IUserSession iUserSession)
        {
            _context = context;
            _dbSet = context.Set<Menu>();
            _iUserSession = iUserSession;
        }

        public async Task<MenuRequest> GetMenu(PaginadoRequest PaginadoResponse)
        {
            int beginRecord = (PaginadoResponse.PageNumber - 1) * PaginadoResponse.PageSize;
            MenuRequest request = new MenuRequest();
            request.TotalRows = await _dbSet.Where(x => true).CountAsync();
            request.Menus = await _dbSet.Where(x => true ).OrderByDescending(x => x.Id).Skip(beginRecord).Take(PaginadoResponse.PageSize).ToListAsync();
            return request;
        }

        public async Task<List<Menu>> GetAllMenu()
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
                menuToInsert.FecIngreso = System.DateTime.Now;
                menuToInsert.UsuarioIngresa = _iUserSession.Username;
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
            menuToUpd.UsuarioActualiza = _iUserSession.Username;
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
            menuToDelete.UsuarioActualiza = _iUserSession.Username;
            //en la tabla se definio como BIT
            menuToDelete.Tittle = false  ;
            _dbSet.Update(menuToDelete);
            await _context.SaveChangesAsync();
            return menuToDelete;
        }

    }
}
