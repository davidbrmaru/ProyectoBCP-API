using ProyectoBCP_API.Models;
using ProyectoBCP_API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProyectoBCP_API.Helpers;

namespace ProyectoBCP_API.Service.Impl
{
    public class ChapterAreaLeaderService : IChapterAreaLeaderServices
    {
        private DataContext _context;
        private DbSet<ChapterAreaLeader> _dbSet;
        public ChapterAreaLeaderService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<ChapterAreaLeader>();
        }
        public async Task<List<ChapterAreaLeader>> GetChapterAreaLeader()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<ChapterAreaLeader> GetChapterById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ChapterAreaLeader> GetChapterByMatricula(string matricula)
        {
            return await _dbSet.Where(p => p.CodMatricula == matricula).FirstOrDefaultAsync();
        }
        public async Task<ChapterAreaLeader> InsertChapterAreaLeader(ChapterAreaLeader chapter)
        {
            ChapterAreaLeader chapterAreaLeaderToValidate = await GetChapterByMatricula(chapter.CodMatricula);

            if (chapterAreaLeaderToValidate == null)
            {
                ChapterAreaLeader chapterAreaLeaderToInsert = new ChapterAreaLeader();
                chapterAreaLeaderToInsert.CodMatricula = chapter.CodMatricula;
                chapterAreaLeaderToInsert.Nombres = chapter.Nombres;
                chapterAreaLeaderToInsert.ApellidoPaterno = chapter.ApellidoPaterno;
                chapterAreaLeaderToInsert.ApellidoMaterno = chapter.ApellidoMaterno;
                chapterAreaLeaderToInsert.FecIngreso = System.DateTime.Now;
                chapterAreaLeaderToInsert.UsuarioIngresa = chapter.UsuarioIngresa;
                chapterAreaLeaderToInsert.FlgActivo = Constants.FlgActivo;

                _dbSet.Add(chapterAreaLeaderToInsert);
                await _context.SaveChangesAsync();
                return chapterAreaLeaderToInsert;
            }
            else
            {
                return chapterAreaLeaderToValidate;
            }
            
        }
        public async Task<ChapterAreaLeader> UpdateChapterAreaLeader(int id,ChapterAreaLeader chapter)
        {
            ChapterAreaLeader chapterAreaLeaderToUp = await GetChapterById(id);
            chapterAreaLeaderToUp.Nombres = chapter.Nombres;
            chapterAreaLeaderToUp.ApellidoPaterno = chapter.ApellidoPaterno;
            chapterAreaLeaderToUp.ApellidoMaterno = chapter.ApellidoMaterno;
            chapterAreaLeaderToUp.FecActualiza = System.DateTime.Now;
            chapterAreaLeaderToUp.UsuarioActualiza=chapter.UsuarioActualiza;
            
            _dbSet.Update(chapterAreaLeaderToUp);
            await _context.SaveChangesAsync();
            return chapterAreaLeaderToUp;
        }
        public async Task<ChapterAreaLeader> DeleteAsyncByid(int id, ChapterAreaLeader chapter)
        {
            ChapterAreaLeader chapterAreaLeaderToDelete = await GetChapterById(id);
            chapterAreaLeaderToDelete.FecActualiza = System.DateTime.Now;
            chapterAreaLeaderToDelete.UsuarioActualiza = chapter.UsuarioActualiza;
            chapterAreaLeaderToDelete.FlgActivo = Constants.FlgDesactivo;
            _dbSet.Update(chapterAreaLeaderToDelete);
            //_dbSet.Remove(chapterAreaLeaderToDelete);
            await _context.SaveChangesAsync();
            return chapterAreaLeaderToDelete;
        }
        public async Task<ChapterAreaLeader> DeleteAsync(int id)
        {
            ChapterAreaLeader chapterAreaLeaderToDelete = await GetChapterById(id);
            _dbSet.Remove(chapterAreaLeaderToDelete);
            await _context.SaveChangesAsync();
            return chapterAreaLeaderToDelete;
        }
    }
}
