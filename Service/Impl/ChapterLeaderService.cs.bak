using ProyectoBCP_API.Models;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace ProyectoBCP_API.Service.Impl
{
    public class ChapterLeaderService : IChapterLeaderService
    {
        private DataContext _context;
        private DbSet<ChapterLeader> _dbSet;
        public ChapterLeaderService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<ChapterLeader>();
        }
        public async Task<List<ChapterLeader>> GetChapterLeader()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<ChapterLeader> GetChapterById(int id)
        {
            return await _dbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ChapterLeader> GetChapterByMatricula(string matricula)
        {
            return await _dbSet.Where(p => p.CodMatricula == matricula).FirstOrDefaultAsync();
        }
        public async Task<ChapterLeader> InsertChapterLeader(ChapterLeader chapter)
        {
            ChapterLeader chapterLeaderToValidate = await GetChapterByMatricula(chapter.CodMatricula);

            if (chapterLeaderToValidate == null)
            {
                ChapterLeader chapterLeaderToInsert = new ChapterLeader();
                chapterLeaderToInsert.IdChapterAreaLeader= chapter.IdChapterAreaLeader;
                chapterLeaderToInsert.CodMatricula = chapter.CodMatricula;
                chapterLeaderToInsert.Nombres = chapter.Nombres;
                chapterLeaderToInsert.ApellidoPaterno = chapter.ApellidoPaterno;
                chapterLeaderToInsert.ApellidoMaterno = chapter.ApellidoMaterno;
                chapterLeaderToInsert.NombreChapter = chapter.NombreChapter;
                chapterLeaderToInsert.FecIngreso = System.DateTime.Now;
                chapterLeaderToInsert.UsuarioIngresa = chapter.UsuarioIngresa;
                chapterLeaderToInsert.FlgActivo = Constants.FlgActivo;

                _dbSet.Add(chapterLeaderToInsert);
                await _context.SaveChangesAsync();
                return chapterLeaderToInsert;
            }
            else
            {
                return chapterLeaderToValidate;
            }

        }
        public async Task<ChapterLeader> UpdateChapterLeader(int id, ChapterLeader chapter)
        {
            ChapterLeader chapterLeaderToUp = await GetChapterById(id);
            chapterLeaderToUp.IdChapterAreaLeader= chapter.IdChapterAreaLeader;
            chapterLeaderToUp.Nombres = chapter.Nombres;
            chapterLeaderToUp.ApellidoPaterno = chapter.ApellidoPaterno;
            chapterLeaderToUp.ApellidoMaterno = chapter.ApellidoMaterno;
            chapterLeaderToUp.ApellidoMaterno = chapter.ApellidoMaterno;
            chapterLeaderToUp.FecActualiza = System.DateTime.Now;
            chapterLeaderToUp.UsuarioActualiza = chapter.UsuarioActualiza;

            _dbSet.Update(chapterLeaderToUp);
            await _context.SaveChangesAsync();
            return chapterLeaderToUp;
        }
        public async Task<ChapterLeader> DeleteAsyncByid(int id, ChapterLeader chapter)
        {
            ChapterLeader chapterLeaderToDelete = await GetChapterById(id);
            chapterLeaderToDelete.FecActualiza = System.DateTime.Now;
            chapterLeaderToDelete.UsuarioActualiza = chapter.UsuarioActualiza;
            chapterLeaderToDelete.FlgActivo = Constants.FlgDesactivo;
            _dbSet.Update(chapterLeaderToDelete);
            await _context.SaveChangesAsync();
            return chapterLeaderToDelete;
        }
        public async Task<ChapterLeader> DeleteAsync(int id)
        {
            ChapterLeader chapterLeaderToDelete = await GetChapterById(id);
            _dbSet.Remove(chapterLeaderToDelete);
            await _context.SaveChangesAsync();
            return chapterLeaderToDelete;
        }

    }
}
