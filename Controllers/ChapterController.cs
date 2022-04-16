using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;
using log4net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoBCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterLeaderService _chapterLeaderServices;
        private readonly ILog log;
        public ChapterController(IChapterLeaderService chapterLeaderServices)
        {
            this._chapterLeaderServices = chapterLeaderServices;
            log=LogManager.GetLogger(typeof(ChapterController));
        }

        // GET: api/<ChapterController>
        [HttpGet]
        public async Task<IEnumerable<ChapterLeader>> GetChapterLeader()
        {
            log.Info("Inicio Get Chapters");
            return await _chapterLeaderServices.GetChapterLeader();
        }

        // GET api/<ChapterController>/5
        [HttpGet("{id}")]
        public async Task<ChapterLeader> GetChapterLeaderbyId(int id)
        {
            log.Info("Inicio Get Chapters ById");
            return await _chapterLeaderServices.GetChapterById(id);
        }

        // POST api/<ChapterController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ChapterLeader chapter)
        {
            log.Info("Inicio Post Chapters");
            var result = await _chapterLeaderServices.InsertChapterLeader(chapter);
            return Ok(result);
        }

        // PUT api/<ChapterController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ChapterLeader chapter)
        {
            log.Info("Inicio Put Chapter ById");
            var result = await _chapterLeaderServices.UpdateChapterLeader(id, chapter);
            return Ok(result);
        }

        // DELETE api/<ChapterController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] ChapterLeader chapter)
        {
            log.Info("Inicio Delete Chapter ById");
            var result = await _chapterLeaderServices.DeleteAsyncByid(id, chapter);
            return Ok(result);
        }
    }
}
