using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public VideoGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/videogames
        [HttpGet]
        public IActionResult Get()
        {
            var VideoGames = _context.VideoGames.Include(c => c.User);
            return Ok(VideoGames);
        }

        // GET api/videogames/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var videoGame = _context.VideoGames.Where(vg => vg.Id == id).Include(u => u.User);
            return Ok(videoGame);
        }

        // POST api/videogames
        [HttpPost]
        public IActionResult Post([FromBody] VideoGame value)
        {
            _context.VideoGames.Add(value); 
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/videogames/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VideoGame value)
        {
            var videoGame = _context.VideoGames.Where(_vg => _vg.Id == id).Include(u => u.User).SingleOrDefault();
            
            _context.VideoGames.Update(value);

            _context.SaveChanges();
            return Ok(videoGame);
        }

        // DELETE api/<VideoGamesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var videoGame = _context.VideoGames.Where(_vg => _vg.Id == id).SingleOrDefault();

            _context.VideoGames.Remove(videoGame);
            _context.SaveChanges();
            return StatusCode(200, videoGame);
        }
    }
}
