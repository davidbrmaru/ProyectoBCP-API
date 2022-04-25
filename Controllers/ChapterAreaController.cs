using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;
using log4net;
using ProyectoBCP_API.Models.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoBCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterAreaController : ControllerBase
    {
        private readonly IChapterAreaLeaderServices _chapterAreaLeaderServices;
        private readonly ILog log;
        public ChapterAreaController(IChapterAreaLeaderServices chapterAreaLeaderServices) 
        {
            this._chapterAreaLeaderServices = chapterAreaLeaderServices;
            log = LogManager.GetLogger(typeof(ChapterAreaController));
        }
        
        // GET: api/<ChapterAreaController>
        [HttpGet]
        public async Task<ChapterAreaLeaderRequest> GetChapterAreaLeader([FromQuery] PaginadoRequest PaginadoResponse)
        {
            log.Info("Inicio Get ChaptersArea");
            return await _chapterAreaLeaderServices.GetChapterAreaLeader(PaginadoResponse);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IEnumerable<ChapterAreaLeader>> GetAllChapterAreaLeader()
        {
            log.Info("Inicio Get All Chapters");
            return await _chapterAreaLeaderServices.GetAllChapterAreaLeader();
        }

        // GET api/<ChapterAreaController>/5
        [HttpGet("{id}")]
        public async Task<ChapterAreaLeader> GetChapterAreaLeaderbyId(int id)
        {
            log.Info("Inicio Get ChaptersArea By Id");
            return await _chapterAreaLeaderServices.GetChapterById(id);
        }

        // POST api/<ChapterAreaController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ChapterAreaLeader chapter)
        {
            log.Info("Inicio Post ChaptersArea");
            var result = await _chapterAreaLeaderServices.InsertChapterAreaLeader(chapter);
            return Ok(result);
        }

        // PUT api/<ChapterAreaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ChapterAreaLeader chapter)
        {
            log.Info("Inicio Put ChapterArea ById");
            var result = await _chapterAreaLeaderServices.UpdateChapterAreaLeader(id, chapter);
            return Ok(result);
        }
        /*
        // DELETE api/<ChapterAreaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteAsyncById(int id, [FromBody] ChapterAreaLeader chapter)
        {
            var result = await _chapterAreaLeaderServices.DeleteAsyncByid(id, chapter);
            return Ok(result);
        }*/

        // DELETE api/<ChapterAreaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] ChapterAreaLeader chapter)
        {
            log.Info("Inicio Delete ChapterArea ById");
            var result = await _chapterAreaLeaderServices.DeleteAsyncByid(id, chapter);
            return Ok(result);
        }
    }
}
