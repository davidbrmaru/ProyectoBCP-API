using ProyectoBCP_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Service
{
    public interface IChapterAreaLeaderServices
    {
        Task<List<ChapterAreaLeader>> GetChapterAreaLeader();
        Task<ChapterAreaLeader> GetChapterById(int id);
        Task<ChapterAreaLeader> InsertChapterAreaLeader(ChapterAreaLeader chapter);
        Task<ChapterAreaLeader> UpdateChapterAreaLeader(int id, ChapterAreaLeader chapter);
        Task<ChapterAreaLeader> DeleteAsyncByid(int id, ChapterAreaLeader chapter);
        Task<ChapterAreaLeader> DeleteAsync(int id);
    }
}
