using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoBCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterAreaController : ControllerBase
    {
        private readonly IChapterAreaLeaderServices _chapterAreaLeaderServices;
        public ChapterAreaController(IChapterAreaLeaderServices chapterAreaLeaderServices) 
        {
            this._chapterAreaLeaderServices = chapterAreaLeaderServices;
        }
        
        // GET: api/<ChapterAreaController>
        [HttpGet]
        public async Task<IEnumerable<ChapterAreaLeader>> GetChapterAreaLeader()
        {
            return await _chapterAreaLeaderServices.GetChapterAreaLeader();
        }

        // GET api/<ChapterAreaController>/5
        [HttpGet("{id}")]
        public async Task<ChapterAreaLeader> GetChapterAreaLeaderbyId(int id)
        {
            return await _chapterAreaLeaderServices.GetChapterById(id);
        }

        // POST api/<ChapterAreaController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ChapterAreaLeader chapter)
        {
            var result = await _chapterAreaLeaderServices.InsertChapterAreaLeader(chapter);
            return Ok(result);
        }

        // PUT api/<ChapterAreaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ChapterAreaLeader chapter)
        {
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
            var result = await _chapterAreaLeaderServices.DeleteAsyncByid(id, chapter);
            return Ok(result);
        }
    }
}
